    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            foreach (var contractDescription in ImplementedContracts.Values)
            {
                contractDescription.Behaviors.Add(new UnityInstanceProvider(container));
            }
        }
    }
