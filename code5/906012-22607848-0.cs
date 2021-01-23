    public class Person {
    	public string ID { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public int Age { get; set; }
    	
    	private PropertyInfo GetProperty(string name) {
    		PropertyInfo property = GetType().GetProperty(name);
    		
    		if (property == null) {
    			throw new ArgumentException(string.Format("Class {0} doesn't expose a {1} property", GetType().Name, name));
    		}
    		
    		return property;			
    	}
    	
    	public string GetStringProperty(string name) {
    		var property = GetProperty(name);
    		return (string) property.GetValue(this, null);
    	}
    	
    	public T GetProperty<T>(string name) {
    		var property = GetProperty(name);
    		return (T) property.GetValue(this, null);
    	}
    }
