    public static T GetExpectedFunction<T>(string functionName) where T : class {
        try {
            if (!typeof(T).IsSubclassOf(typeof(Delegate))) throw new ApplicationException("GetExpectedFunction must return a delegate!");
            var foundMethod = Type.GetType("test2.test2").GetMethod(functionName, BindingFlags.Public | BindingFlags.Static);
            var inv = typeof(T).GetMethod("Invoke");
            var parameters = inv.GetParameters().Zip(foundMethod.GetParameters(), (a, b) => new {
                PassedIn = a.ParameterType
            ,   Reflected = b.ParameterType
            ,   Parameter = Expression.Parameter(a.ParameterType)
            }).ToList();
            if (parameters.All(p => p.PassedIn == p.Reflected)) {
                // Bind directly
                return (T)(object)Delegate.CreateDelegate(typeof(T), foundMethod);  
            }
            var call = Expression.Call(foundMethod, parameters.Select(
                p => p.PassedIn==p.Reflected
            ?   (Expression)p.Parameter
            :   Expression.Convert(p.Parameter, p.Reflected)
            ));
            return (T) (object) Expression.Lambda(typeof(T), call, parameters.Select(p => p.Parameter)).Compile();
        } catch (Exception e) {
            // "Error binding to target method!"
            return null;
        }
    }
