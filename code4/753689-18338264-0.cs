    public static class NotificationExtensions
    {
        private const String NotificationsKey = "MyApp.Notifications";
        public static void AddNotification(this ControllerBase controller, String message)
        {
            ICollection<String> messages = controller.TempData[NotificationsKey] as ICollection<String>;
            if (messages == null)
            {
                controller.TempData[NotificationsKey] = (messages = new HashSet<String>());
            }
            messages.Add(message);
        }
        public static IEnumerable<String> GetNotifications(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.Controller.TempData[NotificationsKey] as ICollection<String> ?? new HashSet<String>();
        }
    }
