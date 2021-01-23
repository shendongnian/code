    public MainPageViewModel : ViewModelBase // I'll explain ViewModelBase momentarily
    {
        public MyUserControlViewModel InnerVM { get; set; } // should be a notifying property
        public MainPageViewModel( ViewModelBase parent, FrameworkElement owner )
            : base( parent, owner )
        {
        }
    }
