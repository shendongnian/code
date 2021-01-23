        scanner.ChangeTextBoxText += scanner_ChangeTextBoxText;
        private void scanner_ChangeTextBoxText(object sender, FS.TextEventArgs e)
        {
            addMessage(e.Message);
        }
        delegate void SetTextCallback(string text);
        private void addMessage(string message)
        {
            if (edtContents.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addMessage);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                edtContents.Text += String.Format("{0}{1}", message, Environment.NewLine);
                edtContents.SelectionStart = edtContents.Text.Length;
                edtContents.ScrollToCaret();
            }
        }
