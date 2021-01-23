    [DataContract]
    public class Settings
    {
        [DataMember]
        public string Session_File { get; set; }
        [DataMember]
        public string Training_catalogue { get; set; }
        [DataMember]
        public string Users_ID { get; set; }
        [DataMember]
        public string File_with_badge_ID { get; set; }
        [DataMember]
        public string Session_Folder { get; set; }
        [DataMember]
        public string PDF_Folder { get; set; }
        public static Settings ReadSettings(string Filename)
        {
            using (var stream = new FileStream(Filename, FileMode.OpenOrCreate))
                try
                {
                    return new DataContractSerializer(typeof(Settings)).ReadObject(stream) as Settings;
                }
                catch { return new Settings(); }
        }
        public void Save(string Filename)
        {
            using (var stream = new FileStream(Filename, FileMode.Create, FileAccess.Write))
                new DataContractSerializer(typeof(Settings)).WriteObject(stream, this);
        }
        public Settings()
        {
            //defaults
        }
    }
