    var tmpObj = new AnyInvokeObject(args => {
                         Console.WriteLine("Invoked dynamic delegate with following parameters:");
                         for (var j = 0; j < args.Length; j++)
                             Console.WriteLine("  {0}: {1}", j, args[j]);
                         if (retType != typeof(void))
                             return Activator.CreateInstance(retType);
                         return null;
                    });
    methodParams[i] = Dynamic.CoerceToDelegate(tmpObj, paramInfo.ParameterType);
    
