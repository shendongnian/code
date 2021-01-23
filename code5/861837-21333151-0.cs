    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
            {
                e.Cancel=true;
                webBrowser.InvokeScript("eval", "history.go(-1)" );
            }
