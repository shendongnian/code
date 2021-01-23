    public partial class MainViewController : UIViewController
    {
        private Binding<bool, bool> _isUpdatedBinding;
        private MainViewModel ViewModel { get; set; }
    
        public MainViewController()
            : base("MainViewController", null)
        {
            this.ViewModel = new MainViewModel();
        }
    
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
    
            _isUpdatedBinding = this.SetBinding(() => this.ViewModel.IsUpdated).WhenSourceChanges(() =>
                {
                    this.updateLabel.Text = this.ViewModel.IsUpdated ? "It's okay !" : "Nope ...";
                });
    
            this.updateButton.SetCommand("TouchUpInside", this.ViewModel.UpdateCommand);
    
        }
    }
