    public class EntityType1 : Entity
    {
        public virtual IList<EntityType1ToNote> Notes {get;set;}
        ...
    public class EntityType2 : Entity
    {
        public virtual IList<EntityType2ToNote> Notes { get; set; }
        ...
