    async void YourLoginButtonEventHandler() {
        int id = User.GetId(user, password); // returns 0 if the user does not exists
        if (id != 0) {
            await Task.Run(() => User.LoadCurrentUser(id));  // Loads the CurrentUser object
            InitializeSystem();
        }
    }
