    public class Artist : IComparable
        {
        public string name;
        public string members;
        public string albums;
        public Guid artistID;
        public List<String> albums;
    
        public Artist()
        {
          artistID = new Guid();
        }
    
        public Artist(string name, string members, string album)
        {
            this.name = name;
            this.members = members;
        }
    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    
        public string Members
        {
            get { return members; }
            set { members = value; }
        }
    
        public string Albums
        {
            get { return albums; }
            set { albums = value; }
        }
    
        public int CompareTo(object obj)
        {
            if (obj is Artist)
            {
                Artist other = (Artist)obj;
                return name.CompareTo(other.name);
            }
            if (obj is string)
            {
                string other = (string)obj;
                return members.CompareTo(other);
            }
            else
            {
                return -999;
            }
        }
