    //this is ugly, but the quickest way I could filter down to the overload that 
    //doesn't take in the IList interface arguments
    var method = typeof (YOUR_CONTROLLER_CLASS).GetMethods(
                 BindingFlags.Instance | BindingFlags.NonPublic)
                .First(m => m.IsGenericMethod 
                    && m.Name == "AutoMap" 
                    && !m.GetParameters()[0].ParameterType.IsInterface);
    var genericMethod = method.MakeGenericMethod(new[] {typeof (a), typeof (b)});
    genericMethod.Invoke(controller, new object[]{ obj_a, obj_b });
