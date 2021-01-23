    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <ListView x:Name="View"
                  SelectionChanged="Selector_OnSelectionChanged" IsSynchronizedWithCurrentItem="True" ItemsSource="{Binding Items}"/>
        <Button Grid.Row="1" Command="{Binding ChangeSelectionCommand}">Set</Button>       
    </Grid> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            View.ScrollIntoView(View.SelectedItem);
        }
    }
    public class ViewModel
    {
        private readonly CollectionViewSource _source = new CollectionViewSource();
        public ICollectionView Items
        {
            get { return _source.View; }
        }
        public ICommand ChangeSelectionCommand { get; set; }
        public ViewModel()
        {
            SetUp();
            ChangeSelectionCommand = new Command(ChangeSelection);
        }
        private void SetUp()
        {
            var list = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i.ToString(CultureInfo.InvariantCulture));
            }
            _source.Source = list;
        }
        private void ChangeSelection()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var n = random.Next(100);
            Items.MoveCurrentToPosition(n);
        }
    }
    public class Command : ICommand
    {
        private readonly Action _action;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _action();
        }
        public event EventHandler CanExecuteChanged;
        public Command(Action action)
        {
            _action = action;
        }
    }
