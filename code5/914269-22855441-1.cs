    public class User
    {
        private List<Photo> _photos;
    
        public string GivenName { get; set; }
    
        public string FamilyName { get; set; }
    
        public List<Photo> Photos
        {
            get
            {
                return this._photos ?? (this._photos = new List<Photo>());
            }
        }
    }
