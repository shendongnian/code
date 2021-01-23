	public class ChildContainerPerJobFilterAttribute : JobFilterAttribute, IServerFilter
	{
		public ChildContainerPerJobFilterAttribute(UnityJobActivator unityJobActivator)
		{
			UnityJobActivator = unityJobActivator;
		}
		public UnityJobActivator UnityJobActivator { get; set; }
		public void OnPerformed(PerformedContext filterContext)
		{
			UnityJobActivator.DisposeChildContainer();
		}
		public void OnPerforming(PerformingContext filterContext)
		{
			UnityJobActivator.CreateChildContainer();
		}
	}
