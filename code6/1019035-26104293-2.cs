    namespace NHibernate.Cache
    {
    	/// <summary>
    	/// A cache provider placeholder used when caching is disabled.
    	/// </summary>
    	public class NoCacheProvider : ICacheProvider
    	{
    		private static readonly IInternalLogger log = LoggerProvider
                .LoggerFor(typeof(NoCacheProvider));
    
    		public const string WarnMessage = "Second-level cache is enabled in a class,"+
                                  " but no cache provider was selected. Fake cache used.";
            ....
