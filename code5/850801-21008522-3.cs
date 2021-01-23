    void Main()
    {   
    	Foo("x", "y");	
    }
    
    public static void Foo (string string1, string string2) {
       var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.GetProperties().FirstOrDefault(y => y.Name == string1) != null);
       var obj = Activator.CreateInstance(type);
       var prop = type.GetProperty(string1, BindingFlags.Public | BindingFlags.Instance);
       if(prop != null && prop.CanWrite) {
            prop.SetValue(obj, string2, null);
       }
       
       Console.WriteLine ((obj as Test).x);
    }
    
    class Test {
    	public String x {get; set; }
    }
