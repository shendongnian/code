        public class Club
    {
        public int ClubID { get; set; }
        
        public string ClubName{ get; set; }
        public virtual ICollection<Match> Host{ get; set; }
        public virtual ICollection<Match> Gest{ get; set; }
    }
