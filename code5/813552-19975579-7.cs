    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow: Window, INotifyPropertyChanged
        {
            private string _currentItem;
            private string _currentSubitem;
            private ObservableCollection<string> _possibleItems;
            private ObservableCollection<string> _possibleSubitems;
            public MainWindow()
            {
                InitializeComponent();
                LoadPossibleItems();
                CurrentItem = PossibleItems[0];
                UpdatePossibleSubItems();
                DataContext = this;
                CurrentItem = PossibleItems[0];
                CurrentSubitem = PossibleSubitems[0];
                PropertyChanged += (s, o) =>
                    {
                        if (o.PropertyName != "CurrentItem") return;
                        UpdatePossibleSubItems();
                        ValidateCurrentSubItem();
                    };
            }
            private void ValidateCurrentSubItem()
            {
                if (!PossibleSubitems.Contains(CurrentSubitem))
                {
                    CurrentSubitem = PossibleSubitems[0];
                }
            }
            public ObservableCollection<string> PossibleItems
            {
                get { return _possibleItems; }
                private set
                {
                    if (Equals(value, _possibleItems)) return;
                    _possibleItems = value;
                    OnPropertyChanged();
                }
            }
            public ObservableCollection<string> PossibleSubitems
            {
                get { return _possibleSubitems; }
                private set
                {
                    if (Equals(value, _possibleSubitems)) return;
                    _possibleSubitems = value;
                    OnPropertyChanged();
                }
            }
            public string CurrentItem
            {
                get { return _currentItem; }
                private set
                {
                    if (value == _currentItem) return;
                    _currentItem = value;
                    OnPropertyChanged();
                }
            }
            public string CurrentSubitem
            {
                get { return _currentSubitem; }
                set
                {
                    if (value == _currentSubitem) return;
                    _currentSubitem = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void LoadPossibleItems()
            {
                PossibleItems = new ObservableCollection<string>
                    {
                        "Item 1",
                        "Item 2"
                    };
            }
            private void UpdatePossibleSubItems()
            {
                if (CurrentItem == PossibleItems[0])
                {
                    PossibleSubitems = new ObservableCollection<string>
                        {
                            "Subitem A",
                            "Subitem B"
                        };
                }
                else if (CurrentItem == PossibleItems[1])
                {
                    PossibleSubitems = new ObservableCollection<string>
                        {
                            "Subitem B",
                            "Subitem C"
                        };
                }
            }
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
