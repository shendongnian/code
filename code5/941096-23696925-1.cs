     public class Grp
    {
       
        public string UniqueId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        private List<item> _Items=new List<item>();
        public List<item> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        
       
    }
     public class item
    {
        public string UniqueId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
