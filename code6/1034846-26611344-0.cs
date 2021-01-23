            if(!string.IsNullOrEmpty(textBoxAttachment.Text.Trim()))
            {
                Attachment data = new Attachment(textBoxAttachment.Text.Trim());
                mail.Attachments.Add(data);
            }
            if(!string.IsNullOrEmpty(textBoxAttachment2.Text.Trim()))
            {
                Attachment data = new Attachment(textBoxAttachment2.Text.Trim());
                mail.Attachments.Add(data);
            }
            if(!string.IsNullOrEmpty(textBoxAttachment3.Text.Trim()))
            {
                Attachment data = new Attachment(textBoxAttachment3.Text.Trim());
                mail.Attachments.Add(data);
            }
            
