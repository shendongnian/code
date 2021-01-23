    [XmlRoot("export")]
    public class NotificationCollection
    {
    
      [XmlElement("notificationZK", typeof(NotificationTypeZK))]
      [XmlElement("notificationFF", typeof(NotificationTypeFF))]
      public List<NotificationType> Notifications { get; set; }
    
    }
    
    public class NotificationType
    {
    
    }
    
    public class NotificationTypeZK : NotificationType { }
    
    public class NotificationTypeFF : NotificationType { }
    
    static void Main(string[] args)
    {
      var data = @"<export><notificationZK /><notificationZK /><notificationFF /></export>";
    
      var serializer = new XmlSerializer(typeof(NotificationCollection));
    
      using (var reader = new StringReader(data))
      {
        var notifications = serializer.Deserialize(reader);
      }
    }
