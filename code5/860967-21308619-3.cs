    public static class RuntimeMethodExtensions
    {
     public static MethodInfo GetRuntimeMethodsExt(this Type type, string name, params Type[] types)
     {
      // Find potential methods with the correct name and the right number of parameters
      // and parameter names
      var potentials = (from ele in type.GetMethods()
                        where ele.Name.Equals(name)
                        let param = ele.GetParameters()
                        where param.Length == types.Length
                        && param.Select(p => p.ParameterType.Name).SequenceEqual(types.Select(t => t.Name))
                        select ele);
    
      // Maybe check if we have more than 1? Or not?
      return potentials.FirstOrDefault();
     }
    }
