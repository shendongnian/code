    public enum ScrollBarDirection { Vertical, Horizontal } ;
    public class HideScrollButtonsBehavior : Behavior<ScrollBar>
    {
        public ScrollBarDirection Direction { get; set; }
        
        public double VerticalScrollAmount
        {
            get { return (double)GetValue(VerticalScrollAmountProperty); }
            set { SetValue(VerticalScrollAmountProperty, value); }
        }
        public static readonly DependencyProperty VerticalScrollAmountProperty =
            DependencyProperty.Register("VerticalScrollAmount", typeof(double), typeof(HideScrollButtonsBehavior), new PropertyMetadata(ScrollChanged));
        public double ScrollExtent
        {
            get { return (double)GetValue(ScrollExtentProperty); }
            set { SetValue(ScrollExtentProperty, value); }
        }
        public static readonly DependencyProperty ScrollExtentProperty =
            DependencyProperty.Register("ScrollExtent", typeof(double), typeof(HideScrollButtonsBehavior), new PropertyMetadata(null));
        public double ViewportExtent
        {
            get { return (double)GetValue(ViewportExtentProperty); }
            set { SetValue(ViewportExtentProperty, value); }
        }
        public static readonly DependencyProperty ViewportExtentProperty =
            DependencyProperty.Register("ViewportExtent", typeof(double), typeof(HideScrollButtonsBehavior), new PropertyMetadata(null));
        public static void ScrollChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue as double? == null)
                return;
            var owner = (HideScrollButtonsBehavior)sender;
            ScrollBar scrollBar = owner.AssociatedObject;
            double scrollPosition = (double)args.NewValue;
            if (scrollPosition <= 0)
                VisualStateManager.GoToState(scrollBar, owner.Direction + "DownOnly", true);
            else if (scrollPosition >= owner.ScrollExtent - owner.ViewportExtent)
                VisualStateManager.GoToState(scrollBar, owner.Direction + "UpOnly", true);
            else
                VisualStateManager.GoToState(scrollBar, owner.Direction + "Both", true);
        }
    }
