      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          InitializeChart();
        }
    
        private void InitializeChart()
        {
          tChart1.Series.Add(new Steema.TeeChart.Styles.Bar()).FillSampleValues();
    
          tChart1[0].GetSeriesMark += Form1_GetSeriesMark;      
          tChart1[0].Marks.Visible = false;
    
          tChart1.Tools.Add(new Steema.TeeChart.Tools.MarksTip());
        }
    
        void Form1_GetSeriesMark(Steema.TeeChart.Styles.Series series, Steema.TeeChart.Styles.GetSeriesMarkEventArgs e)
        {
          e.MarkText = "X: " + series.XValues[e.ValueIndex].ToString() + ", Y: " + series.YValues[e.ValueIndex].ToString() + " - " + series.ToString();
        }    
      }
    
