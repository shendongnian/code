    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (this.allowedToClose == false)
        {
            e.Cancel = true;
        }
    }
