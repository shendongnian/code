    public void StripAttachments(ItemId id)
    {
        EmailMessage email = EmailMessage.Bind(service, id)
        foreach (Attachment a in email.Attachments)
        {
            if (a is FileAttachment)
            {
                // do your thing
            }
        }
    }
