    btn_RemoveAttachment.Click += new System.EventHandler((s, e3) => {
        var senderButton = (Button)s;
        var currentAttachmentIndex = (int)senderButton.Tag;
        removeAttachment(s, 
                         e3,
                         attachmentFiles[currentAttachmentIndex].ToString(), 
                         attachmentNames[currentAttachmentIndex].ToString())
    });
