    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public List<int> Values { get; private set; }
    
            public int ValuesToShow { get; set; }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                ValuesToShow = 20;
    
                Values = new List<int>();
                var random = new Random();
                for (int i = 0; i < 1000000; i++)
                {
                    int next = random.Next(10, 50);
                    Values.Add(next);
                }
    
                hScrollBar1.Maximum = (Values.Count - 1) - ValuesToShow;
    
                RefreshChart();
            }
    
            private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
            {
                RefreshChart();
            }
    
            private IEnumerable<int> GetCurrentValues(int value)
            {
                return Values.Skip(value).Take(ValuesToShow);
            }
    
            private int GetCurrentPosition()
            {
                return hScrollBar1.Value;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ValuesToShow /= 2;
                RefreshChart();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                ValuesToShow *= 2;
                RefreshChart();
            }
    
            private void RefreshChart()
            {
                int value = GetCurrentPosition();
                IEnumerable<int> enumerable = GetCurrentValues(value);
    
                chart1.Series.Clear();
                var series = new Series();
    
                foreach (int i in enumerable)
                {
                    series.Points.Add((double) i);
                }
    
                chart1.Series.Add(series);
            }
        }
    }
