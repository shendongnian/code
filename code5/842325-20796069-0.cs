    [DataContract(Name = "Album", Namespace = "DataContracts")]
    public class Album
    {
        [DataMember(Name = "DicoPhotos")]
        private Dictionary<string, Photo> dicoPhotos = new Dictionary<string, Photo>();
        public Dictionary<string, Photo> DicoPhotos
        {
            get { return dicoPhotos; }
            set { dicoPhotos = value; }
        }
    }
