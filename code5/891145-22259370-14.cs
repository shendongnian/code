        In BrowserForm:
        private void webBrowser1_StatusTextChange(object sender, StatusTextChangeEventArgs e)
        {
            Panel.EventStatusTextChange(e.text);
        }
        In BrowserPanel:
        public void EventStatusTextChange(string text)
        {
            if (_statustext == text) return;
            _statustext s = text;
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => { Owner.StateChanged(this); }));
            else
                Owner.StateChanged(this);
        }
