    for (int i = 0; i < attachmentNames.Count; i++)
    {
        fileName = new Label();
        fileName.Text = attachmentNames[i].ToString();
        pnl_Attachments.Controls.Add(fileName);
    }
