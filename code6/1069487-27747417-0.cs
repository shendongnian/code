    private ObservableCollection<UserModel> allUsers;
    public ObservableCollection<UserModel> AllUsers
    {
        get
        {
            return allUsers;
        }
        set
        {
            allUsers = value;
            NotifyPropertyChanged("AllUsers");
        }
    }
