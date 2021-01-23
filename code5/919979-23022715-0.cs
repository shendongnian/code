    class EllipseAndRectangle : DrawingVisual
    {
        public EllipseAndRectangle()
        {
            using (DrawingContext dc = RenderOpen())
            {
                // Black ellipse with blue border
                dc.DrawEllipse(Brushes.Black,
                    new Pen(Brushes.Blue, 3),        
                    new Point(120, 120), 20, 40); 
     
                // Red rectangle with green border
                dc.DrawRectangle(Brushes.Red,
                    new Pen(Brushes.Green, 4),    
                    new Rect(new Point(10, 10), new Point(80, 80))); 
            }
        }
    }
