    public class Nav
        {
            public ICollection<Jam> Jams {get;set;}
        }
        
        public class Jam
        {
            public ICollection<Nav> Navs {get;set;}
        }
