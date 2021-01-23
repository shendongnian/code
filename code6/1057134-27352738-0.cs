    public class AppModelView
        {
            private ObservableCollection<UserModel> _userList;
            DispatcherTimer LogTimer;
    
            public AppModelView()
            {
                _userList = new ObservableCollection<UserModel>();
                LogTimer = new DispatcherTimer();
                LogTimer.Interval = TimeSpan.FromMilliseconds(10000);
    
                LogTimer.Tick += (s, e) =>
                {
                    Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal,
                     new Action(
                         delegate()
                         {
                             UserList.Add(new UserModel
                             {
                                 userID = "test"
                             });
                         }
                     )
                    );
                };
                LogTimer.Start();
            }
    
            public ObservableCollection<UserModel> UserList
            {
                get { return _userList; }
                set
                {
                    _userList = value;
                    NotifyPropertyChanged("UserList");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
