    public abstract class ViewModel<T>
        where T : EntityModel, new()
    {
        public static ViewModel<T> FromEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
    
    public abstract class EntityModel
    {
        //... properties, methods etc...
    }
