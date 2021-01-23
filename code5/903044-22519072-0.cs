      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          Background = Brushes.Transparent;
        }
    
        protected override void OnRender(DrawingContext dc)
        {
          base.OnRender(dc);
          var whitePen = new Pen();
          whitePen.Brush = Brushes.White;
          for (int y = 0; y < 10; y++)
          {
            for (int x = 0; x < 10; x++)
            {
              dc.DrawLine(whitePen, new Point(x*20, y*20), new Point(x*20 + 10, y*20+10));
              dc.DrawLine(whitePen, new Point(x*20, y*20+10), new Point(x*20 + 10, y*20));
            }
          }
        }
      }
