    public partial class ThreeWay : UserControl
    {
        #region ActiveImage
        public static readonly DependencyProperty ActiveImageProperty =
            DependencyProperty.Register(
                "ActiveImage",
                typeof(ImageSource),
                typeof(ThreeWay),
                new UIPropertyMetadata());
        public ImageSource ActiveImage
        {
            get { return (ImageSource)GetValue(ActiveImageProperty); }
            set { SetValue(ActiveImageProperty, value); }
        }
        #endregion
        //InactiveImage and DerpImage snipped to keep this short
        #region ImageState
        public static readonly DependencyProperty ImageStateProperty =
            DependencyProperty.Register(
                "ImageState",
                typeof(State),
                typeof(ThreeWay),
                new UIPropertyMetadata(State.Derp, OnImageStatePropertyChanged));
        private static void OnImageStatePropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ThreeWay).OnImageStateChanged(
              e.OldValue as State, e.NewValue as State);
        }
        private void OnImageStateChanged(State oldValue, State newValue)
        {
            switch(newValue)
            {
                case State.Active:
                    this.derpImage.Source = ActiveImage;
                    break;
                case State.Inactive:
                    this.derpImage.Source = InactiveImage;
                    break;
                case State.Derp:
                    this.derpImage.Source = DerpImage;
                    break;
            }
        }
        public State ImageState
        {
            get { return (State)GetValue(ImageStateProperty); }
            set { SetValue(ImageStateProperty, value); }
        }
        #endregion
        
        public ThreeWay()
        {
            InitializeComponent();
        }
        public enum State
        {
            Active,
            Inactive,
            Derp
        }
    }
