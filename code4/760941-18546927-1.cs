    public event EventHandler<AddUserEventArgs> AddedUser;
    
    private void Button_Click(Object sender, RoutedEventArgs)
    {
        User info = new User();
        // Realize your validation here...
    
        // If validation is Okay, then..
        if (OK)
        {
            if (this.AddedUser != null)
                this.AddedUser(this, new AddUserEventArgs(info));
            this.Close();
        }
    }
