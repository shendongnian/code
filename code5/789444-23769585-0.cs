    if (attachment is FileAttachment)
    {
             if (attachment.Name.Contains(".xml") || attachment.Name.Contains(".pdf"))
             {
                 FileAttachment fileAttachment = attachment as FileAttachment;
                 fileAttachment.Load("c:\\folder\\" + fileAttachment.Name);
                 Console.WriteLine("Attachment name: " + fileAttachment.Name);
             }
    }
