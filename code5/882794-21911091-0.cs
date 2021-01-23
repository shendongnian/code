         public class User:INotifyPropertyChanged
            {
                public User(){}
            
                public int User_ID { get; set; }
                public string Name { get; set; }
                private ObservableCollection<UserModuleLevel> user_module_levels = new ObservableCollection<UserModuleLevel>();
            
                public ObservableCollection<UserModuleLevel> UserModuleLevels
                {
                    get
                    { return user_module_levels; }
                    set
                    { 
                      user_module_levels = value; 
                      this.OnPropertyChanged();
                    }
                }
            public event PropertyChangedEventHandler PropertyChanged;
            
                    [NotifyPropertyChangedInvocator]
                    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                    {
                        PropertyChangedEventHandler handler = PropertyChanged;
                        if (handler != null)
                        {
                            handler(this, new PropertyChangedEventArgs(propertyName));
                        }
                    }
            
            }
