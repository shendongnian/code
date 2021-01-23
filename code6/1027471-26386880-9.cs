    public class Nav
    {
        public virtual ICollection<NavJamMap> NavJamMaps {get;set;}
    }
    public class Jam
    {
        public virtual ICollection<NavJamMap> NavJamMaps {get;set;}
    }
    
    public class NavJamMap
    {
        public int NavID {get;set;}
        public int JamID {get;set;}
        public Nav Nav {get;set;}
        public Jam Jam {get;set;}
        public DateTime CreationDate {get;set;}
    }
