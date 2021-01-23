    public interface IContainer<T> { 
       IEnumerable<T> Values { get; }  
    }
    public class MyType : IContainer<IServer>
    {
        public IEnumerable<IServer> Servers
        {
            get
            {
                yield return new Server1();
                yield return new Server2();
            }
        }
        IEnumerable<IServer> IContainer<IServer>.Values
        {
            get { return this.Servers; }
        }
    }
    public class AggregatedEnumerableModule<T> : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            if (registration.Activator.LimitType.IsArray)
            {
                Type elementType = registration.Activator.LimitType.GetElementType();
                if (elementType == typeof(T))
                {
                    registration.Activating += (sender, e) =>
                    {
                        IEnumerable<T> originalValues = (IEnumerable<T>)e.Instance;
                        IEnumerable<T> newValues = e.Context.Resolve<IContainer<T>>().Values;
                        IEnumerable<T> aggregatedValues = newValues.Concat(originalValues);
                        e.ReplaceInstance(aggregatedValues);
                    };
                }
            }
            base.AttachToComponentRegistration(componentRegistry, registration);
        }
    }
