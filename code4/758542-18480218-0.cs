    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        if(MessageBox.Show("Are you sure you want to exit?","Confirm Exit?", 
                                MessageBoxButton.OKCancel) != MessageBoxResult.OK)
        {
            e.Cancel = true; 
    
        }
    }
