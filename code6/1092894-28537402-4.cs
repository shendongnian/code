    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MenuView : UserControl
    {
        [ImportingConstructor]
        public MenuView(MenuViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
