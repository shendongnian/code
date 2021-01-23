    class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student > Students { get; set; }
    }
