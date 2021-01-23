    namespace WpfApplication1
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Role> AllRoles { get; private set; }
        public MainWindow()
        {
            this.InitializeComponent();
            var allRoles = new ObservableCollection<Role>();
            allRoles.Add(new Role{ip = "bob"});
            allRoles.Add(new Role{ip = "john"});
            this.AllRoles = allRoles;
            TreeViewItemSource = GetNonsCollectionView(allRoles);
        }
        public CollectionView DataGridViewSource { get; private set; }
        public CollectionView TreeViewItemSource { get; private set; }
        public CollectionView GetNonsCollectionView(ObservableCollection<Role> nonsList)
        {
            return (CollectionView)CollectionViewSource.GetDefaultView(nonsList);
        }
    }
    public class Role : INotifyPropertyChanged
    {
        public string ip { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
