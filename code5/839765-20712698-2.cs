    public partial class ShowFooterController : ViewController
    {
        public ShowFooterController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnAfterConstruction()
        {
            base.OnAfterConstruction();
            this.ViewControlsCreated += SummarizeGridDataController_ViewControlsCreated;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        private void SummarizeGridDataController_ViewControlsCreated(object sender, EventArgs e)
        {
            var listView = this.View as ListView;
            if (listView != null)
            {               
                GridControl grid = (GridControl)View.Control;
                if (grid != null)
                {
                    foreach (var view in grid.Views)
                    {
                        GridView gridView = view as GridView;
                        if (gridView != null)
                        {
                            gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                            gridView.OptionsView.ShowFooter = true;
                        }
                    }
                }
            }
            // Hide action from menu.  This must be done here, after the footer has already been show
            // If it is done earlier than this, the footer will not display
            this.Active.SetItemValue("deactivate", false);
        }
    }
}
