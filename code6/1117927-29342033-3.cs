    // Get all the methods in the interface
    foreach (var method in typeof(IYourInterface).GetMethods())
    {
      var parameters = method.GetParameters().Select(i => i.ParameterType).ToArray();
    
      // We can only compile lambda expressions into a static method, so we'll have this helper. this is going to be YourClassBase.
      var helperMethod = typeBuilder.DefineMethod
            (
                "s:" + method.Name,
                MethodAttributes.Private | MethodAttributes.Static,
                method.ReturnType,
                new [] { method.DeclaringType }.Union(parameters).ToArray()
            );
    
      // The actual instance method
      var newMethod = 
        typeBuilder.DefineMethod
            (
                method.Name, 
                MethodAttributes.Public | MethodAttributes.Virtual, 
                method.ReturnType,
                parameters
            );
      // Compile the static helper method      
      Build(method).CompileToMethod(helperMethod);
      
      // We still need raw IL to call the helper method
      var ilGenerator = newMethod.GetILGenerator();
      
      // First argument is (YourClassBase)this, then we emit all the other arguments.
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Castclass, typeof(YourClassBase));
      for (var i = 0; i < parameters.Length; i++) ilGenerator.Emit(OpCodes.Ldarg, i + 1);
      
      ilGenerator.Emit(OpCodes.Call, helperMethod);
      ilGenerator.Emit(OpCodes.Ret);
      
      // "This method is an implementation of the given IYourInterface method."
      typeBuilder.DefineMethodOverride(newMethod, method);
    }
