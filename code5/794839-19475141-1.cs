    public class Conference {
        public string Title { get; set; }
        public string OwnerName { get; set; }
        public virtual ICollection<DialInNumber> DialInNumbers { get; set; }    
    }
