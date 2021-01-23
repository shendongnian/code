    [Serializable]
    public class ProgramInfo
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlIgnore]
        public Version Version { get; set; }
        [XmlAttribute("Version")
        public string VersionString 
        { 
          get { return this.Version.ToString(); } 
          set{ this.Version = Parse(value);}
        }
    }
