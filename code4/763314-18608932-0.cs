    if (emailNotificationData == null)
    {
        // This is a helper method calling LogProvider.Log(...)
        LogEmailNotificationError("No email notification data");
        return;
    }
    if (string.IsNullOrEmpty(emailNotificationData.Sender))
    {
        LogEmailNotificationError("No sender");
        return;
    }
    if (emailNotificationData.ToRecipients == null)
    {
        LogEmailNotificationError("No recipients");
        return;
    }
