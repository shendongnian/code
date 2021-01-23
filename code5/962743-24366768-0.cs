    public class Component
    {
        public Guid ID { get; set; }
        public Guid Name { get; set; }
        public virtual Component Master { get; set; }
        public virtual ICollection<Component> Components { get; set; }
        // reference to the parent guid (if any)
        public Guid? MasterID { get; set; }
    }
