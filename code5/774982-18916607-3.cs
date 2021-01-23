    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x302 && Clipboard.ContainsText())
        {
            var cbText = Clipboard.GetText(TextDataFormat.Text);
            // Now you can manipulate the text.
            // using you example in the comments, let's remove single
            // and double quotes from the text:
            cbText = cbText.Replace("'", "").Replace("\"", "");
            this.SelectedText = cbText;
        }
        else
            base.WndProc(ref m);
    }
