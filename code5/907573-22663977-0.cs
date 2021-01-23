    // Return the first ten items.
    ItemView view = new ItemView(10);
    // Set the query string to only find emails with attachments.
    string querystring = "HasAttachments:true Kind:email";
    // Find the items in the Inbox.
    FindItemsResults<Item> results = service.FindItems(WellKnownFolderName.Inbox, querystring, view);
    // Loop through the results.
    foreach (EmailMessage email in results)
    {
        // Load the email message with the attachments
        email.Load(new PropertySet(EmailMessageSchema.Attachments));
        // Loop through the attachments.
        foreach (Attachment attachment in email.Attachments)
        {
            // Only process item attachments.            
            if (attachment is ItemAttachment)
            {
                ItemAttachment itemAttachment = attachment as ItemAttachment;
                // Load the attachment.
                itemAttachment.Load(new PropertySet(EmailMessageSchema.TextBody));
                // Output the body.
                Console.WriteLine(itemAttachment.Item.TextBody);
            }
    }
