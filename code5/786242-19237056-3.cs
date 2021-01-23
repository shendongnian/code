     // Copies the text in the text box to the clipboard.
        private void private void textClipboard_LostFocus(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(textClipboard.Text)
            {
                Clipboard.SetText(textClipboard.Text);
                
            }
            else
            {
              copyButton.Enabled = false; //Set to disabled
            }
        }
