    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        Grid CurrentGrid;
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentGrid != null)
                CurrentGrid.Height = 100;
            if (!e.AddedItems.Any())
                return;
            var container = (sender as ListView).ContainerFromItem(e.AddedItems.First());
            var presenter = VisualTreeHelper.GetChild(container, 0);
            CurrentGrid = VisualTreeHelper.GetChild(presenter, 0) as Grid;
            CurrentGrid.Height = 150;
        }
    }
    public class MyViewModel
    {
        ObservableCollection<string> _Items = new ObservableCollection<string>
            (Enumerable.Range(1, 20).Select(x => x.ToString()));
        public ObservableCollection<string> Items { get { return _Items; } }
    }
