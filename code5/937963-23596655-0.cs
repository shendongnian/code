    class Module
    {
        public Module()
        {
            this.Students = new List<Student>();
        }
        public int ModuleID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
