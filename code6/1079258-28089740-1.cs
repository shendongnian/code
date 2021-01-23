    [assembly: Dependency(typeof(SimpleStorage))]
    namespace MyApp.iOS
    {
    	public class SimpleStorage : ISimpleStorage
    	{
    		public void Set (string key, string value)
    		{
    			NSString newKey = new NSString (key);
    			NSString newValue = new NSString (value);
    
    			NSUserDefaults.StandardUserDefaults.SetValueForKey (newValue, newKey);
    		}
    
    		public string Get (string key)
    		{
    			NSString newKey = new NSString (key);
    			NSString value = (NSString)NSUserDefaults.StandardUserDefaults.ValueForKey (newKey);
    
    			return value != null ? value.ToString () : null;
    		}
    
    		public void Delete (string key)
    		{
    			NSString newKey = new NSString (key);
    			NSUserDefaults.StandardUserDefaults.RemoveObject (newKey);
    		}
    	}
    }
