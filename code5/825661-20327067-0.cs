    public partial class ANIME
    {
        public int ID_AN { get; set; }
        public string TITLE_OR { get; set; }
        public string TITLE_EN { get; set; }
        public virtual ICollection<GENRES> GENRES { get; set; } // Use ICollection here
    }
