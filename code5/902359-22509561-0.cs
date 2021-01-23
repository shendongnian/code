    ObservableCollection<User> _UpdatedUsers = new ObservableCollection<User>();
    int _verifiedUsersCount = 0;
    DatabaseServiceLocal _dataService = new DatabaseServiceLocal(Database);
    
    //Verify unique users
    private void SaveUsers(bool CloseForm)
    {
       
        _dataService.CheckIsUserNameUnique += CheckIsUserNameUnique;
        foreach (UserViewModel _User in _AllUsers)
        {
            //bool success = _dataService.IsUserNameUnique(_User.UserName, _User.UserID, Database.CurrentClient.ClientID);
            if (_User.Dirty && !_User.IsBlank)
            {
                _dataService.IsUserNameUnique(_User.UserName, _User.UserID, Database.CurrentClient.ClientID);
            }
        }
    }
    //Store verified users to save
    private void CheckIsUserNameUnique(object s, CheckIsUserNameUniqueEventArgs e)
    {
        if (e.IsUnique)
            _UpdatedUsers.Add(_User.SaveAsUser());
        else
        {
            csaMessageBox.Show(string.Format("Username {0} is not allowed as it already exists in the system. Please choose a different username.", ""), null);
        }
        verifiedUsersCount++;
        //Call after all the users have been verified for uniqueness
        if (_AllUsers.Count() == verifiedUsersCount)
        {
            OnUniqueUserVerifyComplete();
        }
    }
    //Save verified users
    private void OnUniqueUserVerifyComplete()
    {
        //No unique users 
        if (_UpdatedUsers.Count < 1) { return; }
        _dataService.UpdateStaffAndUsersCompleted += (s, e) =>
        {
            BusyIndicator = false;
            if (e.Success)
            {
            }
            if (CloseForm)
                ReturnToHomePage();
            else
            {
                LoadUsers();
                OnUsersSaved();
            }
        };
        BusyIndicator = true;
        BusyMessage = "Saving...";
        _dataService.UpdateUsers(Database.CurrentProject.ProjectID, Database.CurrentClient.ClientID, _UpdatedUsers, _DeletedProjectUsers);
    }
