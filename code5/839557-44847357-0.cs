    Base base1 = new Child1();
    
    MethodInfo method = typeof(Extensions).GetMethod("DoSomething", new System.Type[] { base1.GetType() });
    if (method) {
        method.Invoke(new object[] { base1 });
    }
