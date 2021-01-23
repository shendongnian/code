    public class HeightBehavior : DependencyObject, IBehavior
    {
        public GridView GridView
        {
            get { return (GridView)GetValue(GridViewProperty); }
            set { SetValue(GridViewProperty, value); }
        }
    public static readonly DependencyProperty GridViewProperty =
        DependencyProperty.Register("GridView", typeof(GridView), typeof(HeightBehavior), new PropertyMetadata(null));
    public FrameworkElement FirstItem
    {
        get { return (FrameworkElement)GetValue(FirstItemProperty); }
        set { SetValue(FirstItemProperty, value); }
    }
    public static readonly DependencyProperty FirstItemProperty =
        DependencyProperty.Register("FirstItem", typeof(FrameworkElement), typeof(HeightBehavior), new PropertyMetadata(null));
    public FrameworkElement SecondItem
    {
        get { return (FrameworkElement)GetValue(SecondItemProperty); }
        set { SetValue(SecondItemProperty, value); }
    }
    public static readonly DependencyProperty SecondItemProperty =
        DependencyProperty.Register("SecondItem", typeof(FrameworkElement), typeof(HeightBehavior), new PropertyMetadata(null));
    public DependencyObject AssociatedObject { get; set; }
    public void Attach(DependencyObject associatedObject)
    {
        this.AssociatedObject = associatedObject;
        var control = (Panel)this.AssociatedObject;
        control.Loaded += AssociatedObject_Loaded;
    }
    private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
    {
        this.FirstItem.SizeChanged += FirstItem_SizeChanged;
        this.SecondItem.SizeChanged += SecondItem_SizeChanged;
        // force to re-calculate the Height
        this.FirstItem.Width += 0.5;
    }
    private void FirstItem_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        this.SetAssociatedObjectsHeight();
    }
    private void SecondItem_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        this.SetAssociatedObjectsHeight();
    }
    private void SetAssociatedObjectsHeight()
    {
        this.GridView.Height = this.FirstItem.ActualHeight - this.SecondItem.ActualHeight;
    }
    public void Detach()
    {
        this.FirstItem.SizeChanged -= FirstItem_SizeChanged;
        this.SecondItem.SizeChanged -= SecondItem_SizeChanged;
        var control = (Panel)this.AssociatedObject;
        control.Loaded -= AssociatedObject_Loaded;
    }
