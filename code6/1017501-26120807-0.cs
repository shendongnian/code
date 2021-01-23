      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          InitializeChart();
        }
    
        private void InitializeChart()
        {
          //tChart1.Dock = DockStyle.Fill;
          tChart1.Aspect.View3D = false;
          tChart1.Zoomed += tChart1_Zoomed;
    
          Steema.TeeChart.Styles.Points points1 = new Steema.TeeChart.Styles.Points(tChart1.Chart);
    
          Random y = new Random();
          for (int i = 0; i < 10000; i++)
          {
            points1.Add(DateTime.Now.AddHours(i), y.Next());
          }
    
          points1.XValues.DateTime = true;
          points1.Pointer.HorizSize = 1;
          points1.Pointer.VertSize = 1;
    
          Steema.TeeChart.Functions.DownSampling downSampling1 = new Steema.TeeChart.Functions.DownSampling(tChart1.Chart);
          downSampling1.Method = Steema.TeeChart.Functions.DownSamplingMethod.Average;
          downSampling1.Tolerance = 100;
          downSampling1.DisplayedPointCount = Convert.ToInt32(downSampling1.Tolerance * 4);
    
          Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line(tChart1.Chart);
          line1.Function = downSampling1;
          line1.DataSource = points1;
          line1.Marks.Visible = true;
          line1.Marks.Style = MarksStyles.PointIndex;
    
          UpdateTitle();
        }
    
        void tChart1_Zoomed(object sender, EventArgs e)
        {
          tChart1[1].CheckDataSource();
          UpdateTitle();
        }
    
        private void UpdateTitle()
        {
          tChart1.Header.Text = (tChart1[1].Function as Steema.TeeChart.Functions.DownSampling).DisplayedPointCount.ToString();
        }
      }
