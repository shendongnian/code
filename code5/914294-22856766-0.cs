    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {   e.Cancel=true; 
        string caption = "Stop music and exit?";
        string message = "If you want to continue listen music while doing other stuff, please use Home key instead of Back key. Do you still want to exit?";
        if(MessageBox.Show(message, caption, MessageBoxButton.OKCancel)==MessageboxResult.Ok)
        {
           //exit;
        }
        else
        {
          //do what ever you like
        }
        base.OnBackKeyPress(e);
    }
