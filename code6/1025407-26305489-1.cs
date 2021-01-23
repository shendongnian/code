    private void removeAttachment(object sender, EventArgs e)
    {
        var thisButton = sender as Button;
        var index = Convert.ToInt32(thisButton.Tag);
        var thisLabel = (Label) Controls.Find("Label" + index, true).First();
        // Remove the files
        attachmentNames.Remove(attachmentNames[index]);
        attachmentFiles.Remove(attachmentFiles[index]);
        // Remove the associated controls
        pnl_Attachments.Controls.Remove(thisButton);
        pnl_Attachments.Controls.Remove(thisLabel);
    }
