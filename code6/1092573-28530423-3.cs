    var mailDocuments = Context.Documents.Local // Local!
                               .Where(d => d.Type == EnumDocumentType.Mail)
                               .ToList();
    foreach(var md in mailDocuments)
    {
        Context.Entry(md).State = System.Data.Entity.EntityState.Detached;
        if (md.File != null)
        {
            Context.Entry(md.File).State = System.Data.Entity.EntityState.Detached;
        }
    }
