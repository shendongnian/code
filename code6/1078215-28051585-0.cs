    // Save to Drafts folder
    await outlook.Me.AddMessageAsync(m);
    
    foreach (var attach in me.Attachments)
    {
        var file = attach.File;
        var fileversion = file.GetVersion(attach.Version);
        string fullpath = LibraryServiceImpl.GetFullNameInArchive(fileversion);
        var mattach = new FileAttachment { Name = file.Name, ContentId = attach.ContentId, ContentLocation = fullpath, ContentType = GraphicUtils.DetermineMime(Path.GetExtension(fullpath)) };
        if (file.Name.MissingText())
            mattach.Name = attach.ContentId + fileversion.FileExtension;
        m.Attachments.Add(mattach);
    }
    
    // Update with attachments
    await m.UpdateAsync();
    // Send the message
    await m.SendAsync();
