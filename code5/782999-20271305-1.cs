        namespace GraphApp
    {    
        public class BasicGraph:FrameworkElement
        {
        Canvas Graph;
        VisualCollection vc;
        DrawingContext dc;
        double x_center;
        double y_center;
        
        public BasicGraph()
        {
            vc  = new VisualCollection(this);
            this.Loaded += new RoutedEventHandler(Draw_Loaded);
            this.LayoutUpdated += new EventHandler(Draw_Updated);
        }
        public void UpdateLayout()
        {
            this.UpdateLayout();
        }
        void DrawAxes()
        {
            Point leftMid = new Point(0,this.ActualHeight/2);
            Point rightMid = new Point(this.ActualWidth, this.ActualHeight / 2);
            Point topMid = new Point(this.ActualWidth / 2, 0);
            Point bottomMid = new Point(this.ActualWidth / 2, this.ActualHeight); 
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawLine(new Pen(Brushes.Black, 1.0), leftMid, rightMid);
                dc.DrawLine(new Pen(Brushes.Black, 1.0), topMid, bottomMid);
            }
            vc.Add(dv);
        }
        void DrawLinePoint(Point p1, Point p2)
        {
            DrawAxes();
        }
        void Draw_Loaded(object sender, RoutedEventArgs args)
        {
            DrawAxes();
            // DrawLinePoint(new Point(1.5, 1.5), new Point(50.0, 50.0));
        }
        void Draw_Updated(object sender, EventArgs args)
        {
            vc.Clear();
            DrawAxes();
        }
        
        
        void GenerateAxes(Canvas GraphWindow)
        {
            double width = GraphWindow.Width;
            double height = GraphWindow.Height;            
        }
        protected override Visual GetVisualChild(int index)
        {
            return vc[index];
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return vc.Count;
            }
        }
        
    }
    }
