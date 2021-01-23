    public abstract class EntityToNote<TEntity>
    {
        public abstract string Discriminator { get; set; }
        public virtual TEntity Entity {get;set;}
        public virtual Note    Note   {get;set;}
    }
    // the pairing objects
    public class EntityType1ToNote : EntityToNote<EntityType1>
    {
        string _discriminator = "EntityType1"; // here we set the discriminator
        public virtual string Discriminator
        {
            get { return _discriminator; }
            set { _discriminator = value; }
        }
    ...
    // Similar for other pairing objects
