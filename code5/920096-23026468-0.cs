    public class Billiard:Control
    {
        public List<Point> Balls { get; private set; } 
        public Billiard()
        {
            Balls=new List<Point>();
        }
        
        protected override void OnBackColorChanged(EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var imageBuffer = new Bitmap(Width, Height))
            {
                using (var graphicsObject=Graphics.FromImage(imageBuffer))
                {
                    graphicsObject.Clear(Color.Green);
                    using (var boundryPen=new Pen(Brushes.SaddleBrown,10))
                    {
                        graphicsObject.DrawRectangle(boundryPen,0,0,Width,Height);
                    }
                    using (var ballPen = new Pen(Brushes.Red, 5))
                    {
                        foreach (var ball in Balls)
                        {
                            graphicsObject.DrawEllipse(ballPen,new Rectangle(ball,new Size(5,5)));
                        }
                    }
                    e.Graphics.DrawImage((Image)imageBuffer.Clone(),0,0);
                }
            }
        }
    }
