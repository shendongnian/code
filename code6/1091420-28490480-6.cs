    public class MenuItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public virtual MenuItem Parent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<MenuItem> Children { get; set; }
    }
