    public abstract class ViewModel<T>
        where T : EntityModel, new()
    {
        public static ViewModel<T> FromEntity(EntityModel e)
        {
            throw new NotImplementedException();
        }
    }
    
    public abstract class EntityModel
    {
        //... properties, methods etc...
    }
