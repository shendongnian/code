        [Serializable()]
        [System.Xml.Serialization.XmlRoot("export")]
        public class NotificationCollection
        {
            [XmlElement("notificationSZType", Type = typeof(notificationSZType))]
            [XmlElement("notificationPOType", Type = typeof(notificationPOType))]
            [XmlElement("notificationZKType", Type = typeof(notificationZKType))]
            [XmlElement("notificationEFType", Type = typeof(notificationEFType))]
            [XmlElement("notificationOKType", Type = typeof(notificationOKType))]
            public notificationType[] notification { get; set; }
        }
