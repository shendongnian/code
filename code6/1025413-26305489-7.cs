    private void removeAttachment(object sender, EventArgs e)
    {
        // Get associated Label and Button controls
        var thisButton = sender as Button;
        var index = Convert.ToInt32(thisButton.Tag);
        var thisLabel = (Label) Controls.Find("NameLabel" + index, true).First();
        // Remove the files
        int itemIndex = attachmentNames.IndexOf(thisLabel.Text);
        attachmentNames.RemoveAt(itemIndex);
        attachmentFiles.RemoveAt(itemIndex);
        // Disable controls and strikethrough the text
        thisButton.Enabled = false;
        thisLabel.Font = new Font(thisLabel.Font, FontStyle.Strikeout);
        thisLabel.Enabled = false;
    }
