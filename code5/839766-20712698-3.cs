        public partial class WinShowFooterController : ViewController<ListView>
    {
        public WinShowFooterController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            bool shouldSetFooterToVisible = this.View != null && this.View.Model != null;
            if (shouldSetFooterToVisible)
            {
                this.View.Model.IsFooterVisible = true;
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
