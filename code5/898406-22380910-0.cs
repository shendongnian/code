    for (int i = 0; i < attachments.Length; i++)
    {
        if (attachments[i].Name != null && attachments[i].Content != null)
        {
            MemoryStream mstream = new MemoryStream(attachments[i].Content);
            AttachmentCreationInformation spAttachment = new AttachmentCreationInformation();
            spAttachment.ContentStream = mstream;
            spAttachment.FileName = attachments[i].Name;
            newItem.AttachmentFiles.Add(spAttachment);
        }
    }
    newItem.Update();
