    Type typInterfaceB = Type.GetType("InterfaceB"); // unless you have no namespace at all, you need to specify the fully qualified name
    // Probably you got an NRE because of above issue here
    MethodInfo methodB = typInterfaceB.GetMethod("MethodB", BindingFlags.Public | BindingFlags.Instance); 
    // this does not work, because the first argument needs to be an instance 
    // try "new ClassB()" instead
    ClassC result = (ClassC) methodB.Invoke(typInterfaceB, new object[]{num});
