    public interface IOpenGenericExtension : IUnityContainerExtensionConfigurator
    {
        void RegisterClosedImpl(Type openGenericInterface, Type closedType);
    }
    public class OpenGenericExtension : UnityContainerExtension, IOpenGenericExtension
    {
        protected override void Initialize() {}
        public void RegisterClosedImpl(Type openGenericInterface, Type closedType)
        {
            closedType.GetInterfaces().Where(x => x.IsGenericType)
                      .Where(x => x.GetGenericTypeDefinition() == openGenericInterface)
                      .ToList()
                      .ForEach(x => Container.RegisterType(x, closedType, closedType.Name));
        }
    }
