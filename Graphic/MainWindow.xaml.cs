using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;


namespace Graphic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // chart.Series.Clear();
                double x1 = double.Parse(X1.Text);
                double x2 = double.Parse(X2.Text);
                double h = double.Parse(H.Text);
                int N = (int)((x2 - x1) / h)+1;
                double[] mas1 = new double[N];
                double[] mas2 = new double[N];
                chart.ChartAreas.Add(new ChartArea("Diagram"));
                chart.Series.Add(new Series("Series1"));
                chart.Series["Series1"].ChartArea = "Diagram";
                chart.Series["Series1"].ChartType = SeriesChartType.Column;
                double x = x1;
                for(int i=0;i<N;i++)
                {
                    mas1[i] = x;
                    mas2[i] = Math.Pow(x, 3) - 4 * x * x + 2;
                    x += h;
                }
                chart.Series["Series1"].Points.DataBindXY(mas1, mas2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
