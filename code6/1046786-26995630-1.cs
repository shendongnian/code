    public ObservableCollection<User> Users
    {
        get { return users; }
        set { users = value; NotifyPropertyChanged("Users"); }
    }
    public User SelectedUser
    {
        get { return user; }
        set { user = value; NotifyPropertyChanged("User"); }
    }
