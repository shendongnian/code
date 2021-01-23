    public class EntityModelBinderProvider
        : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!typeof(Entity).IsAssignableFrom(modelType))
                return null;
    
            Type modelBinderType = typeof(EntityModelBinder<>)
                .MakeGenericType(modelType);
    
            var modelBinder = ObjectFactory.GetInstance(modelBinderType);
    
            return (IModelBinder) modelBinder;
        }
    }
