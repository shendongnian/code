    public partial class PageHeaderControl : UserControl
    {
    public string HeaderTitle 
    {
        get { return (string)GetValue(HeaderTitleProperty); }
        set { SetValue(HeaderTitleProperty, value); }
    }
    public static readonly DependencyProperty HeaderTitleProperty = DependencyProperty.Register("HeaderTitle", typeof(string), typeof(PageHeaderControl), new PropertyMetadata(""));
    public SolidColorBrush HeaderTitleForeground
    {
        get { return (SolidColorBrush)GetValue(HeaderTitleForegroundProperty); }
        set { SetValue(HeaderTitleForegroundProperty, value); }
    }
    public static readonly DependencyProperty HeaderTitleForegroundProperty = DependencyProperty.Register("HeaderTitleForeground", typeof(SolidColorBrush), typeof(PageHeaderControl), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
    public PageHeaderControl()
    {
        InitializeComponent();
        (this.Content as FrameworkElement).DataContext = this;
    }
    }
