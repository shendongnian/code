    using Steema.TeeChart;
    using Steema.TeeChart.Styles;
    using Steema.TeeChart.Tools;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          InitializeChart();
        }
    
        private void InitializeChart()
        {
          testClass();
    
          //existing code which assigns colors
          tChart1.Series.Add(new Steema.TeeChart.Styles.Bar()).FillSampleValues();
    
          tChart1.Series[0].ColorRange(tChart1.Series[0].YValues, double.MinValue, lineYVal, Color.Red);
          tChart1.Series[0].ColorRange(tChart1.Series[0].YValues, lineYVal, double.MaxValue, Color.Blue);
    
          //my attempt to add a line
          tChart1.Tools.Add(line);
          line.Active = true;
          line.Axis = tChart1.Axes.Left;
          line.Value = lineYVal;
        }
    
        private ColorLine line;
        private double lineYVal = 5;
        private TChart savedChart;
    
        public void testClass()
        {
          line = new ColorLine();
          line.AllowDrag = true;
          line.Pen.Color = Color.Red;
          line.EndDragLine += lineDragHandler;
        }
    
        public void foo(TChart chart)          //chart is prepopulated with datapoints from 0->10
        {
          savedChart = chart;
          //existing code which assigns colors
          chart.Series[0].ColorRange(chart.Series[0].YValues, double.MinValue, lineYVal, Color.Red);
          chart.Series[0].ColorRange(chart.Series[0].YValues, lineYVal, double.MaxValue, Color.Blue);
    
          //my attempt to add a line
          chart.Tools.Add(line);
          line.Active = true;
          line.Axis = chart.Axes.Left;
          line.Value = lineYVal;
        }
    
        private void lineDragHandler(object sender)
        {
          lineYVal = line.Value;
          if (savedChart != null)
          {
            savedChart.Tools.Clear();   //remove existing line from chart
            foo(savedChart);              //redo colors and re-add line
          }
          else
          {
            foo(tChart1);
          }
        }
    
      }
    }
