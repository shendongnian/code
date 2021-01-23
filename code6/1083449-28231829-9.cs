	public class ApplicationSettings : IIdentityAppSettings, IEventStoreSettings
	{
		// implement interfaces here
	}
	
	public interface IEventStoreSettings
    {
        string EventStoreUsername { get; }
        string EventStorePassword { get; }
        string EventStoreAddress { get; }
        int EventStorePort { get; }
    }
	
	public interface IIdentityAppSettings
    {
        byte[] StsSigningKey { get; }
    }
