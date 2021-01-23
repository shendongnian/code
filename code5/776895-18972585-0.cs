    [Serializable]
    [XmlRoot("SplashScreen")]
    public class SerializableSplashScreen
    {
        [XmlElement]
        public Image Image { get; set; }
    
        [XmlElement]
        public Song Song { get; set; }
    }
    
    [Serializable]
    public class IsPath
    {
        [XmlElement]
        public List<string> Path { get; set; }
    }
    
    [Serializable]
    public class Image : IsPath
    {
    }
    
    [Serializable]
    public class Song : IsPath
    {
    }
