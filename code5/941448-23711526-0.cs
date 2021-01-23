    public async void DemoEndInvoke()
    {
        MethodDelegate dlgt = new MethodDelegate (this.LongRunningMethod) ;
        string s ;
        int iExecThread;
    
        await Task.Factory.FromAsync(MethodDelegate.BeginInvoke, MethodDelegate.EndInvoke, iExecThread);
    		
        MessageBox.Show (string.Format ("The delegate call returned the string:   \"{0}\", and the number {1}", s, iExecThread.ToString() ) );
    }
