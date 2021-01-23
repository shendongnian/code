     // Copies the text in the text box to the clipboard.
        private void copyButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textClipboard.Text)
               Clipboard.SetText(textClipboard.Text);
        }
