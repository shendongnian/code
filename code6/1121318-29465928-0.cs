        public class EmailNotificationClass
    {
        //EN = EmailNotification OI in the XML document       
        public string EN_NotificationName { get; set; }
        public string EN_EmailAddress { get; set; }
        public string EN_EmailSubject { get; set; }
        public string EN_NotificationText { get; set; }
        public string EN_Status { get; set; }
        public string EN_FilterType { get; set; }
        public List<EN_F_SourceClass> Sources { get; set; }
    }
    public class EN_F_SourceClass
    {
        public string FilterSource { get; set; }
    }
