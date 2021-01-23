    // Gather the abstract method
    let mAbstract = Application.Methods.WithFullName("MyNamespace.IMyInterface.Method1()").Single()
    
    from m in Methods where m.IsUsing(mAbstract)
    
    // Get ctors called by MethodCaller()
    let ctorsCalled = m.MethodsCalled.Where(mc => mc.IsConstructor)
    
    // Get classes that implement IMyInterface instantiated by MethodCaller()
    let classesInstantiated = ctorsCalled.ParentTypes().Where(t => t.Implement("MyNamespace.IMyInterface"))
    
    // Get override of Method1() 'probably' called.
    let overridesCalled = classesInstantiated.ChildMethods().Where(m1 => m1.OverriddensBase.Contains(mAbstract))
    
    select new { m, overridesCalled }
