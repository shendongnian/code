    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        if (MiniBrowser.CanGoBack){
            e.Cancel = true;
            MiniBrowser.InvokeScript("eval", "history.go(-1)");
        }
    }
