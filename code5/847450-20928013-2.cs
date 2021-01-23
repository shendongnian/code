	public class SecureSoapExtension : SoapExtension
	{
		
		public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
		{
			return null;
		}
		public override object GetInitializer(Type serviceType)
		{
			return null;
		}
		public override void Initialize(object initializer)
		{
			
		}
		public override void ProcessMessage(SoapMessage message)
		{
			// just for out requests
			if (message.Stage == SoapMessageStage.BeforeSerialize)
			{
				// add needed soap header here
				message.Headers.Add(new SecureSoapHeader());
			}
		}
	}
