     public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<TabEntry> _tabs ;
        public ObservableCollection<TabEntry> Tabs
        {
            get
            {
                return _tabs;
            }
            set
            {
                if (_tabs == value)
                {
                    return;
                }
                _tabs = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
             Tabs = new ObservableCollection<TabEntry>()
            {
                new TabEntry()
                {
                    Description = "Tab1",
                    DataGridEntries = new ObservableCollection<DataGridEntry>()
                    {
                        new DataGridEntry()
                        {
                            Description = "Tab1 Description 1",
                            Value = "Tab1 Value 1"
                        },
                        new DataGridEntry()
                        {
                            Description = "Tab1 Description 2",
                            Value = "Tab1 Value 2"
                        }
                    }
                },
                 new TabEntry()
                {
                    Description = "Tab2",
                    DataGridEntries = new ObservableCollection<DataGridEntry>()
                    {
                        new DataGridEntry()
                        {
                            Description = "Tab2 Description 1",
                            Value = "Tab2 Value 1"
                        },
                        new DataGridEntry()
                        {
                            Description = "Tab2 Description 2",
                            Value = "Tab2 Value 2"
                        }
                    }
                }
            };
            
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class TabEntry : INotifyPropertyChanged
    {
       
        private String _description;
        public String Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                {
                    return;
                }
                _description = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DataGridEntry> DataGridEntries { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class DataGridEntry : INotifyPropertyChanged
    {
        private String _description;
        public String Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                {
                    return;
                }
                _description = value;
                OnPropertyChanged();
            }
        }
        private String _value;
        public String Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value == value)
                {
                    return;
                }
                _value = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
