    public abstract class IntEntity<TEntity> : IEntity<TEntity, int>
       where TEntity : IntEntity<TEntity>
    {
        public Expression<Func<TEntity, int>> GetIdExpression()
        {
            return (Expression<Func<TEntity, int>>)(e => e.EntityId);
        }
        public abstract int EntityId
        {
            get;
        }
    }
    public partial class Entity2
    {
        public int Id { get; set; }
    }
    //and the manual part:
    public partial class Entity2 : IntEntity<Entity2>
    {
        public override int EntityId
        {
            get { return this.Id; }
        }
    }
