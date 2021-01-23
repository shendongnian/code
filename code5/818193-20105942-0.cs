    var assembly = Assembly.LoadFrom("App.dll");
    var type = assembly.GetType("App.LoadFile");
    
    var args = new string[] { filepath };
    
    var main = type.GetMethod("Main", 
    	System.Reflection.BindingFlags.Static
    	| System.Reflection.BindingFlags.NonPublic
    	| System.Reflection.BindingFlags.InvokeMethod
    	);
    
    main.Invoke(null, new object[] { args });
