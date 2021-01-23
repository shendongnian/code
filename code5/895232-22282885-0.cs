    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace SOWinForm
    {
        public partial class Form1 : Form
        {
            List<Line> lines;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                lines = new List<Line>();
                lines.Add(new Line(){ StartPoint = new Point(10,10), EndPoint = new Point(10,100)});
                lines.Add(new Line() { StartPoint = new Point(10, 10), EndPoint = new Point(50, 50) });
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                foreach (var line in lines)
                {
                    using (var p = new Pen(Color.Black, 3))
                    {
                        e.Graphics.DrawLine(p, line.StartPoint, line.EndPoint);
                    }
                }
            }
        }
        public class Line
        {
            public Point StartPoint {get;set;}
            public Point EndPoint { get; set; }
            //Add Custom Properties
        }
    }
