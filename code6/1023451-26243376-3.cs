    for (int i = 0; i < attachmentNames.Count; i++)
    {
        fileName = new Label();
        fileName.Text = attachmentNames[i].ToString();
        fileName.Location = new Point(x, y);
        y += marginAmount;
        pnl_Attachments.Controls.Add(fileName);
    }
