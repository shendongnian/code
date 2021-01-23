    public class Group
    {
        public int Id {get;set;}
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
