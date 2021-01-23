    void Main()
    {
    	
    	var dummyObject = new Dummy { Test = "Hello!" };
    	
    	var propertyTransform = Create(dummyObject, "Test");
    	
    	propertyTransform(dummyObject);
    	
    	Console.WriteLine("Final transformation " + dummyObject.Test);
    }
    
    class Dummy {
    	public string Test { get; set; }
    }
    
    // Define other methods and classes here
    public class Transformation<TProperty>
    {
    	public Func<TProperty, TProperty> Transform { get; set; }
    }
    
    public static Action<TObj> Create<TObj>(TObj myObject, string property){
    	var prop = myObject
    		.GetType()
    		.GetProperty(property);
    		
    	var val = prop.GetValue(myObject);
    
    	var transformation = Create((dynamic)val);
    	var transform = transformation.Transform;
    	
    	return obj => {
    	
    		var newValue = transform((dynamic)val);
    		
    		prop.SetValue(myObject, newValue);
    	};
    }
    
    public static Transformation<TProperty> Create<TProperty>(TProperty property){
    
    	var transformation = new Transformation<TProperty>();
    	
    	// just a dummy hijacking.
    	if(typeof(TProperty)==typeof(string)){
    
    		Func<string, string> test = input => "I am changed man!";
    	
    		transformation.Transform = (dynamic)test;
    	}
    	
    	return transformation;
    }
