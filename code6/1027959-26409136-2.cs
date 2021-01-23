    public sealed class Upload : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Hello Pat");
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode("Upload Task - Yeah"));
            textElements[1].AppendChild(toastXml.CreateTextNode("I'm message from your Upload task!"));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
