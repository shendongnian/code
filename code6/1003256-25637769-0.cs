    [Serializable]
    public class card
    { }
    [Serializable]
    public class stage
    { }
    [Serializable]
    [XmlInclude(typeof(card)), XmlInclude(typeof(stage))]
    public class serializeHelper
    {
        public object Package { get; set; }
        public string PackageType { get; set; }
        public serializeHelper() { } // required for deserialization
        public serializeHelper(object aPackage)
        { 
            Package = aPackage;
            PackageType = aPackage.GetType().FullName;
        }
    }
