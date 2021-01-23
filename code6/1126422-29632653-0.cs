    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace DragAndDropCircles
    {
        public partial class Form1 : Form
        {
            private List<MyCircle> myCircles = new List<MyCircle>();
            private MyCircle activeCircle;
            private bool drawing = false;
            private bool dragging = false;
            private Pen pen = new Pen(new SolidBrush(Color.Blue));
            private Point dragOffset;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
    
                drawing = false;
                dragging = false;
    
                activeCircle = CheckIfCircleClicked(e.Location);
                if (activeCircle == null)
                {
                    activeCircle = new MyCircle(e.Location, 0);
                    drawing = true;
                }
                else
                {
                    dragging = true;
                    dragOffset = new Point(activeCircle.Point.X - e.Location.X, activeCircle.Point.Y - e.Location.Y);
                }
            }
    
            private MyCircle CheckIfCircleClicked(Point point)
            {
                return
                    myCircles.FirstOrDefault(
                        circle =>
                            Math.Abs(circle.Point.X - point.X) < circle.Radius &&
                            Math.Abs(circle.Point.Y - point.Y) < circle.Radius);
            }
    
    
            public class MyCircle
            {
                public Point Point { get; set; }
                public double Radius { get; set; }
    
                public MyCircle(Point point, Double radius)
                {
                    Point = point;
                    Radius = radius;
                }
            }
    
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (drawing)
                {
                    activeCircle.Radius = Math.Max(Math.Abs(e.Location.X - activeCircle.Point.X),
                        Math.Abs(e.Location.Y - activeCircle.Point.Y));
                    pictureBox1.Invalidate();
                }
                else if (dragging)
                {
                    activeCircle.Point = new Point(e.Location.X + dragOffset.X, e.Location.Y + dragOffset.Y);
                    pictureBox1.Invalidate();
                }
            }
    
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;
    
                if (activeCircle == null)
                    return;
    
                if (dragging)
                {
                    activeCircle.Point = new Point(e.Location.X + dragOffset.X, e.Location.Y + dragOffset.Y);
                }
                else if (drawing)
                {
                    activeCircle.Radius = Math.Max(Math.Abs(e.Location.X - activeCircle.Point.X),
                        Math.Abs(e.Location.Y - activeCircle.Point.Y));
                    myCircles.Add(activeCircle);
                }
                dragging = false;
                drawing = false;
                pictureBox1.Invalidate();
            }
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);
    
                foreach (var circle in myCircles.Where(c=>c!= activeCircle))
                {
                    g.DrawEllipse(pen, (float) (circle.Point.X - circle.Radius), (float) (circle.Point.Y - circle.Radius),
                        (float) (circle.Radius*2),
                        (float) (circle.Radius*2));
                }
    
                if (activeCircle != null)
                {
                    g.DrawEllipse(pen, (float) (activeCircle.Point.X - activeCircle.Radius),
                        (float) (activeCircle.Point.Y - activeCircle.Radius), (float) (activeCircle.Radius*2),
                        (float) (activeCircle.Radius*2));
                }
    
            }
        }
    }
