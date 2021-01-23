      [Serializable]
    
       public   class Entry
        {
           [XmlAttribute]
            public string Key { get; set; }
            [XmlText]
           public string value { get; set; }
        }
