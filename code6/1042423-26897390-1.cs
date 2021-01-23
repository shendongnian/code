      public partial class CircularProgressBar : UserControl 
      {
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register("IsLoading", typeof(bool), typeof(CircularProgressBar), new UIPropertyMetadata(false));
        public bool IsLoading
        {
          get { return (bool)GetValue(IsLoadingProperty); }
          set { SetValue(IsLoadingProperty, value); }
        }
    
        public CircularProgressBar()
        {
          InitializeComponent();
          (this.Content as FrameworkElement).DataContext = this;
        }
      }
