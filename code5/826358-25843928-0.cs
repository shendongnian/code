     using Windows.UI.Notifications;
     
     var toastXmlContent = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
     var txtNodes = toastXmlContent.GetElementsByTagName("text");
     txtNodes[0].AppendChild(toastXmlContent.CreateTextNode("First Line"));
     txtNodes[1].AppendChild(toastXmlContent.CreateTextNode("Second Line" ));
     var toast = new ToastNotification(toastXmlContent);
     var toastNotifier = ToastNotificationManager.CreateToastNotifier();
     toastNotifier.Show(toast);
