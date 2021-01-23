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
    
            public int ValuesToShow
            {
                get { return 20; }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Values = new List<int>();
                var random = new Random();
                for (int i = 0; i < 1000000; i++)
                {
                    int next = random.Next(10, 50);
                    Values.Add(next);
                }
    
                hScrollBar1.Maximum = (Values.Count - 1) - ValuesToShow;
            }
    
            private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
            {
                var hScrollBar = (HScrollBar) sender;
                int value = hScrollBar.Value;
                IEnumerable<int> enumerable = Values.Skip(value).Take(ValuesToShow);
    
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
