    IList<EmailAttachment> emailAttachments = null;
    
    using (var session = PersistenceContext.OpenSession())
    using (var transaction = session.BeginTransaction())
    {
        // seperate attachments from email
        emailAttachments = model.Attachments;
        model.Attachments = null;
    
        session.Save(model);
        session.Flush();
        transaction.Commit();
    }
    
    //LINQ Solution to save attachments
    if (emailTemplateAttachments != null)
    {
        foreach (EmailAttachment attachment in emailAttachments)
        {
            FileHelperDBDataContext context = new FileHelperDBDataContext(_connectionString);
            LinqEmailAttachment linqClone = new LinqEmailAttachment();
            linqClone.blob = new System.Data.Linq.Binary(attachment.Blob);
            linqClone.title = attachment.Title;
            linqClone.email_template_ID = model.Id;
            
            context.LinqEmailTemplateAttachments.InsertOnSubmit(linqClone);
            context.SubmitChanges();
        }
    }
