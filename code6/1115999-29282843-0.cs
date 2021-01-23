    ToastTemplateType toastTemplate = ToastTemplateType.ToastText01; 
    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
    XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
    toastTextElements[0].AppendChild(toastXml.CreateTextNode("Hello World!"));
    ToastNotification toast = new ToastNotification(toastXml);
    ToastNotificationManager.CreateToastNotifier().Show(toast);
