    public void ShowMessage()
    {
       if(this.InvokeRequired)
        {
          this.Invoke(ShoMessage())
         return; 
         }
        MessageBoxExTn.Show(IWin32Window parentForm, string MsgText, string Caption, MessageBoxButtons);
    }
