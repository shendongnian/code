    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        // put any code you like here
        MessageBox.Show("You pressed the Back button");
        e.Cancel = true;                       
    }
