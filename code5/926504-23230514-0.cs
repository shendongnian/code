    public event CommandEventHandler UserCreated;
    
    protected void Button_Click(object sender, EventArgs e)
    {
        // Create a user
        ...
        // User was created successfully, so bubble up the event to parent. 
        UserCreated(this, new CommandEventArgs("UserId", userId.ToString()));
    }
