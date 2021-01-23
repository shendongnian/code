    public interface IEntity
    {
        void Accept(IEntityVisitor visitor);
    }
    public abstract class EntityBase : IEntity
    {
        public virtual void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public abstract class Entity : EntityBase
    {
        public override void Accept(IEntityVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public interface IEntityVisitor
    {
        void Visit(EntityBase entity);
        void Visit(Entity entity);
    }
