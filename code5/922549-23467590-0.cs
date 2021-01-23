    private RepeatButton rb = null;
    private RepeatButton rb1 = null;
    private Thumb thumb = null;
    public ThumbnailUserControl()
    {
      InitializeComponent();
      //sv1 repensented as ScrollViewer's object
      this.sv1.Loaded += new RoutedEventHandler(sv1_Loaded);
    }
    void sv1_Loaded(object sender, RoutedEventArgs e)
    {
            FrameworkElement fe = VisualTreeHelper.GetChild(this.sv1, 0) as FrameworkElement;
            if (fe == null)
                return;
            var sb = fe.FindName("VerticalScrollBar") as ScrollBar;
            if (sb != null)
            {                
                thumb = (Thumb)((FrameworkElement)VisualTreeHelper.GetChild(sb, 0)).FindName("VerticalThumb");
                rb1 = (RepeatButton)((FrameworkElement)VisualTreeHelper.GetChild(sb, 0)).FindName("VerticalLargeDecrease");
                rb = (RepeatButton)((FrameworkElement)VisualTreeHelper.GetChild(sb, 0)).FindName("VerticalSmallIncrease");
                rb.Click += new RoutedEventHandler(rb_Click);
                thumb.DragCompleted += new DragCompletedEventHandler(thumb_DragCompleted);
                thumb.MouseWheel += new MouseWheelEventHandler(thumb_MouseWheel);
            }            
    }
