    public partial class MainWindow : Window
    {   
        ViewModel MyViewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MyViewModel;
            MyViewModel.MyCollection = new ObservableCollection<Person>();
            MyViewModel.MyCollection.Add(new Person()
            {
                Age = 22,
                Name = "Nick",
            });
            MyViewModel.MyCollection.Add(new Person()
            {
                Age = 11,
                Name = "Sam",
            });
            MyViewModel.MyCollection.Add(new Person()
            {
                Name = "Kate",
                Age = 15,
            });
            AddEmptyRow(MyViewModel.MyCollection);
            MyViewModel.PropertyChanged += new PropertyChangedEventHandler(MyViewModel_PropertyChanged);
        }
        private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("MayUserAddRows"))
            {
                if (MyViewModel.MayUserAddRows == true) 
                {
                    MyViewModel.CanUserAddRows = true;
                }
                if (MyViewModel.MayUserAddRows == false)
                {
                    MyViewModel.CanUserAddRows = false;
                    AddEmptyRow(MyViewModel.MyCollection);
                }                
            }
        }
        #region AddEmptyRow
        private void AddEmptyRow(ObservableCollection<Person> collection) 
        {
            collection.Add(new Person()
            {
                Name = "",
                Age = 0,
            });
        }
        #endregion
        #region Clear
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MyViewModel.MyCollection.Clear();
        }
        #endregion
    }
    #region ViewModel
    public class ViewModel : NotificationObject
    {
        #region MyCollection
        public ObservableCollection<Person> MyCollection
        {
            get;
            set;
        }
        #endregion
        #region CanUserAddRows
        private bool _canUserAddRows = false;
        public bool CanUserAddRows
        {
            get
            {
                return _canUserAddRows;
            }
            set
            {
                _canUserAddRows = value;
                NotifyPropertyChanged("CanUserAddRows");
            }
        }
        #endregion
        #region MayUserAddRows
        private bool _mayUserAddRows = false;
        public bool MayUserAddRows
        {
            get
            {
                return _mayUserAddRows;
            }
            set
            {
                _mayUserAddRows = value;
                NotifyPropertyChanged("MayUserAddRows");
            }
        }
        #endregion
    }
    #endregion
    #region Model
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
    }
    
    #endregion
    #region NotificationObject
    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    #endregion
