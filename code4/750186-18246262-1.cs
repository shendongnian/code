    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
    public class ViewModel : PropertyChangedNotifier
    {
        public ViewModel()
        {
            Items = new ObservableCollection<Part>();
            var parent = new Part() { Name = "Parent" };
            parent.SubParts = new ObservableCollection<Part>();
            parent.SubParts.Add(new Part() { Name = "Child1" });
            parent.SubParts.Add(new Part() { Name = "Child2" });
            Items.Add(parent);
        }
        private ObservableCollection<Part> _items;
        public ObservableCollection<Part> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
    }
    public class Part : PropertyChangedNotifier
    {
        private string _name;
        private ObservableCollection<Part> _subParts;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<Part> SubParts
        {
            get { return _subParts; }
            set
            {
                _subParts = value;
                OnPropertyChanged("SubParts");
            }
        }
    }
    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public static class VisualTreeTools
    {
        public static T GetVisualParent<T>(DependencyObject item) where T : DependencyObject
        {
            while (item != null)
            {
                item = VisualTreeHelper.GetParent(item);
                if (item is T)
                    return item as T;
            }
            return null;
        }
    }
    public class TreeViewItemToTopLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var item = value as DependencyObject;
            if (item == null)
                return 0;
            var containerTreeViewItem = VisualTreeTools.GetVisualParent<TreeViewItem>(item);
            var parentTreeViewItem = VisualTreeTools.GetVisualParent<TreeViewItem>(containerTreeViewItem);
            return parentTreeViewItem == null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
