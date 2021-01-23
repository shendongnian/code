    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
        string name = e.NavigationParameter as string;
    
        if (!string.IsNullOrWhiteSpace(name))
        {
            tb1.Text = "Hello, " + name;
        }
        else
        {
            tb1.Text = "Name is required.  Go back and enter a name.";
        }
    }
