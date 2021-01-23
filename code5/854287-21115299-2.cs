    public void ShowMessage(string cap,string message)
        {
            if (this.InvokeRequired)
            {
                Action<string, string> action = ShowMessage;
                this.Invoke(action, new object[] {cap, message});
                return;
            }
           MessageBoxExTn.Show(IWin32Window parentForm, string MsgText, string Caption, MessageBoxButtons);
        }
