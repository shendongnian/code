    var lookup =  notifications.ToLookup(notification =>
        _emailService.SendEmail(notification.Message.Subject, 
            notification.Message.Body,
            notification.Message.MailTo));
    var successfulIDs = lookup[true].SelectMany(notification => notification.ID);
    var errorCount = lookup[false].Count();
