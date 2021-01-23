    public interface IEntity
    {
    }
    public class Entity1 : IEntity
    {
    }
    public class Entity2 : IEntity
    {
    }
    public abstract class Definition<TEntity>
        where TEntity : IEntity
    {
    }
    public class Entity1Definition : Definition<Entity1>
    {
    }
    public class Entity2Definition : Definition<Entity2>
    {
    }
