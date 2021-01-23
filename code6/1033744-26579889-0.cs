    public class People
    {
        public People()
        {
            Files = new List<File>();
        }
        public int PeopleId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
    public class File
    {
        public File()
        {
            Friends = new List<People>();
            Foes = new List<People>();
        }
        public Int16 FileId { get; set; }
        public virtual ICollection<People> Friends { get; set; }
        public virtual ICollection<People> Foes { get; set; }
    }
