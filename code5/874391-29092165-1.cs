        private const double LandscapeShift = -259d;
        private const double LandscapeShiftWithBar = -328d;
        private const double Epsilon = 0.00000001d;
        private const double PortraitShift = -339d;
        private const double PortraitShiftWithBar = -408d;
     
        public static readonly DependencyProperty TranslateYProperty = DependencyProperty.Register("TranslateY", typeof(double), typeof(MainPage), new PropertyMetadata(0d, OnRenderXPropertyChanged));
     
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPageLoaded;
        }
     
        public double TranslateY
        {
            get { return (double)GetValue(TranslateYProperty); }
            set { SetValue(TranslateYProperty, value); }
        }
     
        private static void OnRenderXPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MainPage)d).UpdateTopMargin((double)e.NewValue);
        }
     
        private void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            BindToKeyboardFocus();
        }
     
        private void BindToKeyboardFocus()
        {
            PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null)
            {
                var group = frame.RenderTransform as TransformGroup;
                if (group != null)
                {
                    var translate = group.Children[0] as TranslateTransform;
                    var translateYBinding = new Binding("Y");
                    translateYBinding.Source = translate;
                    SetBinding(TranslateYProperty, translateYBinding);     
                }
            }
        }     
        private void UpdateTopMargin(double translateY)
        {    
          if(IsClose(translateY, LandscapeShift) || IsClose(translateY,PortraitShift) || IsClose(translateY, LandscapeShiftWithBar) || IsClose(translateY, PortraitShiftWithBar))
          {
            LayoutRoot.Margin = new Thickness(0, -translateY, 0, 0);  
          }
        }
     
        private bool IsClose(double a, double b)
        {
            return Math.Abs(a - b) < Epsilon;
        }
     
        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Margin = new Thickness();
        }
