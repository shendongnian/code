    public class ExeNames {
        [XmlIgnore]
        public bool IsLoaded {get; private set;}
        [XmlIgnore]
        const string Filename = "exenames.xml";
        public string SlaveAExe {get; set;}
        public string SlaveBExe {get; set;}
        public string SlaveDExe {get; set;}
        public string SlaveCExe {get; set;}
    
        public void Load() {
          var serializer = new XmlSerializer(typeof(ExeNames));
          using (StreamReader reader = new StreamReader(Filename)) {
            ExeNames End = serializer.Deserialize(reader) as ExeNames;
            if (End == null) return;
            SlaveAExe = End.SlaveAExe;
            SlaveBExe = End.SlaveBExe;
            SlaveDExe = End.SlaveDExe;
            SlaveCExe = End.SlaveCExe;
            IsLoaded = true;
          }
        }
    
        public void Save() {
          var serializer = new XmlSerializer(typeof(ExeNames));
          using (StreamWriter writer = new StreamWriter(Filename)) {
            serializer.Serialize(writer, this);
          }
        }
      }
