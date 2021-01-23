    public MainWindow() {
        User myUser = new User();
    
        myUser.Timer = new System.Timers.Timer(1000);
        myUser.Timer.Elapsed += (sender, e) => OnTimerElapsed(myUser);
        myUser.Timer.AutoReset = true;
        myUser.Timer.Enabled = true;
    }
    private void OnTimerElapsed(User currentUser) {
        MessageBox.Show(string.Format("OnTimerElapsed: {0}, alive {1:0} seconds",
            currentUser.Id, currentUser.Alive.TotalSeconds));
    }
