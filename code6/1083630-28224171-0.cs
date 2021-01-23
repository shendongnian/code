    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClanId {get; set;}    // You might need to make it virtual. Not sure.
        public virtual Clan Clan { get; set; }
    }
    public partial class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
