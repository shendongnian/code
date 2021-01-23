    public class House : Entity<Guid>
    {
        ...
        //public List<Door> Doors { get; set; }
        public virtual IList<Door> Doors { get; set; }
