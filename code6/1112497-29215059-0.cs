    public class ObservableGrid : Grid
    {
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
    
            if (VisualChildrenChanged != null)
                VisualChildrenChanged(this, new VisualChildrenChangedEventArgs(visualAdded, visualRemoved));
        }
    
        public event EventHandler<VisualChildrenChangedEventArgs> VisualChildrenChanged;
    }
    
    public class VisualChildrenChangedEventArgs : EventArgs
    {
        public VisualChildrenChangedEventArgs(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            VisualAdded = visualAdded;
            VisualRemoved = visualRemoved;
        }
    
        public DependencyObject VisualAdded { get; private set; }
        public DependencyObject VisualRemoved { get; private set; }
    }
