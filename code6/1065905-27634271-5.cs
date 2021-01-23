    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class OptionalToolTipBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            base.OnAttached();
        }
        void AssociatedObject_Loaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            ScrollViewer scrollViewer = this.FindScrollViewer(AssociatedObject);
            if (scrollViewer != null)
            {
                this.AssociatedObject.SetBinding(TextBox.ToolTipProperty,
                    new Binding() { Source = scrollViewer, 
                        Path = new PropertyPath(ScrollViewer.ScrollableWidthProperty), 
                            Converter = ScrollableWithToTooltipConverter.Instance, 
                            ConverterParameter=this.AssociatedObject.Text});
            }
        }
        private ScrollViewer FindScrollViewer(DependencyObject element)
        {
            if (element is ScrollViewer) { return element as ScrollViewer; }
            int childCount = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < childCount; i++)
            {
                return this.FindScrollViewer(VisualTreeHelper.GetChild(element, i));
            }
            return null;
        }
        private class ScrollableWithToTooltipConverter : IValueConverter
        {
            public static readonly ScrollableWithToTooltipConverter Instance = new ScrollableWithToTooltipConverter();
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if((double) value > 0)
                {
                    return parameter.ToString();
                }
                return null;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
