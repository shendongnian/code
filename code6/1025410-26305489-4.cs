    for (int i = 0; i < attachmentNames.Count; i++)
    {
        var fileName = new Label
        {
            AutoSize = true,
            Name = "NameLabel" + i, // Set a name for this control so we can find it later
            Text = attachmentNames[i],
            Top = (i + 1) * 22
        };
        pnl_Attachments.Controls.Add(fileName);
        var btn_RemoveAttachment = new Button { Text = "X", Tag = i };
        // Add an existing method rather than a Lambda expression:
        btn_RemoveAttachment.Click += removeAttachment;
        btn_RemoveAttachment.Top = (i + 1) * 22;
        btn_RemoveAttachment.Left = fileName.Right + 22;
        pnl_Attachments.Controls.Add(btn_RemoveAttachment);
    }
