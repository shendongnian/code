    itemAttachment.Load(new PropertySet(BasePropertySet.FirstClassProperties));
    itemAttachment.Load(new PropertySet(
            BasePropertySet.IdOnly,
            ItemSchema.Subject,
            ItemSchema.DateTimeReceived,
            ItemSchema.DisplayTo, 
            EmailMessageSchema.From, EmailMessageSchema.Sender,
            EmailMessageSchema.HasAttachments, ItemSchema.MimeContent,
            EmailMessageSchema.Body, EmailMessageSchema.Sender,
            ItemSchema.Body) { RequestedBodyType = BodyType.Text });
    string BodyText = itemAttachment.Item.Body.Text;
    
    string itemAttachmentName = itemAttachment.Name.Replace(":", "");
    // Put attachment contents into a stream. 
    emailAttachmentsPath = emailAttachmentsPath + "\\" + itemAttachmentName +  ".eml";
    var mimeContent = itemAttachment.Item.MimeContent;
    //save to disk 
    using (var fileStream = new FileStream(emailAttachmentsPath, FileMode.Create))
    {
        fileStream.Write(mimeContent.Content, 0, mimeContent.Content.Length);
    }
