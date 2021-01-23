    [assembly: Dependency(typeof(SimpleStorage))]
    namespace MyApp.Android
    {
    	public class SimpleStorage : ISimpleStorage
    	{
    		public void Set (string key, string value)
    		{
    			var prefs = Forms.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
    			var prefEditor = prefs.Edit();
    
    			prefEditor.PutString (key, value);
    			prefEditor.Commit();
    		}
    
    		public string Get (string key)
    		{
    			var prefs = Forms.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);              
    
    			return prefs.GetString(key, null);
    		}
    
    		public void Delete (string key)
    		{
    			var prefs = Forms.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);              
    			var prefEditor = prefs.Edit ();
    
    			prefEditor.Remove (key);
    			prefEditor.Commit();
    		}
    	}
    }
