    namespace myTask // the Namespace of my task 
    {
       public sealed class FirstTask : IBackgroundTask // sealed - important
       {
          public void Run(IBackgroundTaskInstance taskInstance)
          {
            // simple example with a Toast, to enable this go to manifest file
            // and mark App as TastCapable - it won't work without this
            // The Task will start but there will be no Toast.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode("My first Task"));
            textElements[1].AppendChild(toastXml.CreateTextNode("I'm message from your background task!"));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
          }
       }
     }
