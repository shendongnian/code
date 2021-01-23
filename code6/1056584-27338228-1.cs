    public sealed partial class FirstRunPage : VisualStateAwarePage, INavigateBackwards
    {
        private INavigateBackwards ViewModel
        {
            get
            {
                return (INavigateBackwards)this.DataContext;
            }
        }
        public FirstRunPage()
        {
            this.InitializeComponent();
        }
        public bool CanNavigateBack()
        {
            return ViewModel.CanNavigateBack();
        }
    }
