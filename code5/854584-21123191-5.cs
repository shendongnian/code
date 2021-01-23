    public ViewModelBase
    {
        public ViewModelBase Parent { get; set; } // should be a notifying property
        public FrameworkElement Owner { get; set; } // should be a notifying property
        public ViewModelBase( ViewModelBase parent, FrameworkElement owner )
        {
            Parent = parent;
            Owner = owner;
        }
    }
