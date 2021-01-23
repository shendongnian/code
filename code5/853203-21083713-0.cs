    public partial class MainWindow
    {
        private VirtualizingStackPanel _panel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyViewModel();
        }
        private IList<ChildViewModel> _snapshot = new List<ChildViewModel>();
        private void OnPanelLoaded(object sender, RoutedEventArgs eventArgs)
        {
            _panel = (VirtualizingStackPanel)sender;
            UpdateSnapshot();
            _panel.ScrollOwner.ScrollChanged += (s,e) => UpdateSnapshot();
        }
        private void UpdateSnapshot()
        {
            var layoutBounds = LayoutInformation.GetLayoutSlot(_panel);
            var onScreenChildren = 
                (from visualChild in _panel.GetChildren()
                 let childBounds = LayoutInformation.GetLayoutSlot(visualChild)
                 where layoutBounds.Contains(childBounds) || layoutBounds.IntersectsWith(childBounds)
                 select visualChild.DataContext).Cast<ChildViewModel>().ToList();            
            foreach (var removed in _snapshot.Except(onScreenChildren))
            {
                // TODO: Cancel pending calculations.
                Console.WriteLine("{0} was removed.", removed.Value);
            }
            _snapshot = onScreenChildren;
        }
    }
