	public class TestHandler : IHandleMessages<AMS.Infrastructure.Events.IEvent>
	{
		public void Handle(AMS.Infrastructure.Events.IEvent message)
		{
			Hub.Instance.Proxy.Invoke("ServerFunction", "yodle");
		}
	}
