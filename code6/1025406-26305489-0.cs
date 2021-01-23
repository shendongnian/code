    for (int i = 0; i < attachmentNames.Count; i++)
    {
        var fileName = new Label
        {
            AutoSize = true,
            Name = "Label" + i,
            Text = attachmentNames[i],
            Top = (i + 1) * 22
        };
        pnl_Attachments.Controls.Add(fileName);
        var btn_RemoveAttachment = new Button { Text = "X", Tag = i };
        btn_RemoveAttachment.Click += removeAttachment;  // Add an existing method
        btn_RemoveAttachment.Top = (i + 1) * 22;
        btn_RemoveAttachment.Left = fileName.Right + 22;
        pnl_Attachments.Controls.Add(btn_RemoveAttachment);
    }
