    var message = new MvcMailMessage {Subject = "AdminNotification"};
    foreach (string email in emails)
    {
        message.To.Add(email);
        PopulateBody(message, ViewName = "AdminNotification");
    }
    return message;
