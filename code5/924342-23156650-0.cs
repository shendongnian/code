    private void SomeEvent(object sender, EventArgs e)
    {
        ((AppDelegate)UIApplication.SharedApplication.Delegate).Menu.ShowMenuRight(); 
        //or
        //((AppDelegate)UIApplication.SharedApplication.Delegate).Menu.ShowMenuLeft(); 
    }
