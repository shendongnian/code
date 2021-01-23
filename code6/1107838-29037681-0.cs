    System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
      try
      {
        var myType = typeof(MyType);
        var assembly = myType.Assembly;
        //Get the assembly name with comma. I do not care about version in this instance, but it is generally a good idea to include.
        //ex: MyTypeAssembly,
        var subString = assembly.FullName.Substring(0, assembly.FullName.IndexOf(',') + 1);
        if (args.Name.StartsWith(subString))
          return myType.Assembly;
      }
      catch
      {
        return null;
      }
      return null;
    }
