    public partial class Form1 : Form
    {
        private Chart chart1;
        public Form1()
        {
            InitializeComponent();
            chart1 = new Chart();
            var chartArea1 = new ChartArea();
            chart1.ChartAreas.Add(chartArea1);
            chartArea1.AxisX.IsLogarithmic = true;
            chartArea1.AxisX.Maximum = 1000D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 1;
            var series1 = new Series();
            series1.ChartType = SeriesChartType.Spline;
            series1.Points.Add(new DataPoint(0D, 0D));
            series1.Points.Add(new DataPoint(10D, 10D));
            series1.Points.Add(new DataPoint(100D, 100D));
            chart1.Series.Add(series1);
            chart1.Location = new System.Drawing.Point(10, 10);
            chart1.Size = new System.Drawing.Size(800, 300);
            Controls.Add(this.chart1);
        }
