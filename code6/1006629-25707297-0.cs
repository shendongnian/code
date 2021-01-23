       public partial class InkStringView : UserControl
    {
        public InkStringView()
        {
            InitializeComponent();           
            tbc.Loaded += new RoutedEventHandler(InkStringView_Loaded);
        }
        void InkStringView_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            Typeface typeface = new Typeface(
              tb.FontFamily,
              tb.FontStyle,
              tb.FontWeight,
              tb.FontStretch);
           FormattedText formattedText = new FormattedText(
                tb.Text,
                System.Threading.Thread.CurrentThread.CurrentCulture,
                tb.FlowDirection,
                typeface,
                tb.FontSize,
                tb.Foreground);
            StringViewModel svm = tb.DataContext as StringViewModel;
            svm.Bounds = formattedText.GetBoundingRect();
            svm.MidlineY1 = svm.MidlineY2 =  svm.Bounds.Top + 0.45 * (formattedText.Baseline - svm.Bounds.Top);
            double width = tb.ActualWidth;
            double height = tb.ActualHeight;
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
           
            GeneralTransform gt = tb.TransformToAncestor(parent as UIElement);
            Point offset = gt.Transform(new Point(0, 0));
            double controlTop = offset.Y;
            double controlLeft = offset.X;
        }       
    }
