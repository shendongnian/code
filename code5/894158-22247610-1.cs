    public partial class Group
    {
        public Group()
        {
            //Remove this line!
            //this.Memberships = new List<Membership>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
