    public abstract class ServiceDependencyHost
            {
                protected virtual T ReferenceService<T>() where T : new()
                {
                    return new T();
                }
            }
    
            public sealed class ProcessServiceOperation : ServiceDependencyHost
            {
                protected override T ReferenceService<T>()
                {
                    // Override implementation here...
    
                    return base.ReferenceService<T>();
                }
            }
