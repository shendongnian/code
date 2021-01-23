    // exemple with flag
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (this.allowedToClose == false)
        {
            // this window will not close
            e.Cancel = true;
        }
        else if (this.appMustClose == true)
        {
            // close the app
            Application.Current.Shutdown();
        }
    }
