        public void BrowserPrint()
        { 
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => { webBrowser1.Print(); }));
            else
                webBrowser1.Print();
        }
        public void BrowserClose()
        {
            Browser.DialogResult = DialogResult.Cancel; // or whatever
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => { this.Close(); }));
            else
                this.Close();
        }
