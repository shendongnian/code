    public class Photo
    {
        public string FileName { get; set; }
    
        public DateTime TimeStamp { get; set; }
    }
    
    public class User
    {
        private readonly List<Photo> _photos = new List<Photo>();
    
        public string GivenName { get; set; }
    
        public string FamilyName { get; set; }
    
        public List<Photo> Photos
        {
            get
            {
                return this._photos;
            }
        }
    }
