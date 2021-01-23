    private bool userRequestedExit = false;
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
    
        if (this.userRequestedExit) {
            return;
        }
    
        if (e.CloseReason == CloseReason.WindowsShutDown) return;
    
        switch (MessageBox.Show(this, "Are you sure you want to exit?", "", MessageBoxButtons.YesNo))
        {
            case DialogResult.No:
                e.Cancel = true;
                break;
            default:
                this.userRequestedExit = true;
                Application.Exit();
                break;
        }
    }
