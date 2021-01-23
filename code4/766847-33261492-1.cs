    protected override void OnClosing(CancelEventArgs e)
    {
        if (richTextBox_Query.Modified)
        {
            DialogResult result;
            do
                try
                {
                    richTextBox_Query.SaveFile(
                        Path.ChangeExtension(Application.ExecutablePath, "sql"),
                        RichTextBoxStreamType.UnicodePlainText);
                    result = DialogResult.OK;
                    richTextBox_Query.Modified = false;
                }
                catch (Exception ex)
                {
                    result = MessageBox.Show(ex.ToString(), "Exception while saving sql query",
                        MessageBoxButtons.AbortRetryIgnore);
                    e.Cancel = result == DialogResult.Abort;
                }
            while (result == DialogResult.Retry);
        }
        base.OnClosing(e);
    }
