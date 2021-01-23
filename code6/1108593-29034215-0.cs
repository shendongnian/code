    // Find a type you want to instantiate: you need to know the assembly it's in for it, we assume that all is is one assembly for simplicity
    // You should be careful, because ClassName should be full name, which means it should include all the namespaces, like "ConsoleApplication.MyClass"
    // Not just "MyClass"
    Type type = Assembly.GetExecutingAssembly().GetType(ClassName);
    // Create an instance of the type
    object instance = Activator.CreateInstance(type);
    // Get MethodInfo, reflection class that is responsible for storing all relevant information about one method that type defines
    MethodInfo method = type.GetMethod(MethodName);
    // I've assumed that method we want to call is declared like this
    // public void MyMethod() { ... }
    // So we pass an instance to call it on and empty parameter list
    method.Invoke(instance, new object[0]);
