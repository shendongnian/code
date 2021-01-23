    PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, EmailMessageSchema.IsRead);
    EmailMessage mail = EmailMessage.Bind(service, itemId, propSet);
    if (!mail.IsRead) // check that you don't update and create unneeded traffic
    {
        mail.IsRead = true; // mark as read
        mail.Update(ConflictResolutionMode.AutoResolve); // persist changes
    }
