    public partial class Category : NWatchObjectBase
    {
        public Category()
        {
            this.Tags = new HashSet<Tag>();
            this.Children = new HashSet<Category>();
        }
    
        public int Handle { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual CasModelClass ModelClass { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual Category Parent { get; set; }
    }
