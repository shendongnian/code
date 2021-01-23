        [Serializable]
        [ProtoContract]
        public class Album
        {
    
            private List<Photo> photos = new List<Photo>();
    
            [ProtoMember(1)]
            public List<Photo> Photos
            {
                get { return photos; }
                set
                {
                    photos = value;
                }
            }
    
            private Dictionary<string, Photo> dicoPhotos = new Dictionary<string, Photo>();
            [ProtoMember(2)]
            public Dictionary<string, Photo> DicoPhotos
            {
                get { return dicoPhotos; }
                set { dicoPhotos = value; }
            }
        }
