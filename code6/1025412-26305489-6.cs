    for (int i = 0; i < attachmentNames.Count; i++)
    {
        var lbl_FileName = new Label
        {
            AutoSize = true,
            Name = "Label" + i,  // Give this a name so we can find it later
            Text = attachmentNames[i],
            Top = (i + 1) * 22
        };
        
        var btn_RemoveAttachment = new Button
        {
            Text = "X",
            Tag = i,
            Top = (i + 1) * 22,
            Left = lbl_FileName.Right + 22
        };
        btn_RemoveAttachment.Click += removeAttachment;
        pnl_Attachments.Controls.Add(lbl_FileName);
        pnl_Attachments.Controls.Add(btn_RemoveAttachment);
    }
