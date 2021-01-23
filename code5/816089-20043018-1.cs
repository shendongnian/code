	public class CustomInstanceProvider : IInstanceProvider, IContractBehavior
	{
		private readonly IDependency dependency;
		public CustomInstanceProvider(IDependency dependency)
		{
			this.dependency = dependency;
		}
		public object GetInstance(InstanceContext instanceContext)
		{
			// Here you are injecting dependency by constructor
			return new Service(dependency);
		}
		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			return this.GetInstance(instanceContext);
		}
		public void ReleaseInstance(InstanceContext instanceContext, object instance)
		{
		}
		public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
		{
		}
		public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
		{
			dispatchRuntime.InstanceProvider = this;
		}
		public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}
		public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}
	}
	public class CustomServiceHost : ServiceHost
	{
		public CustomServiceHost(IDependency dependency, Type serviceType, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses)
		{
			foreach (var cd in this.ImplementedContracts.Values)
			{
				cd.Behaviors.Add(new CustomInstanceProvider(dependency));
			}
		}
	}
