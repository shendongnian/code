    var result = provider.CompileAssemblyFromSource(new CompilerParameters(), src);
    if (result.Errors.Count == 0)
    {
        var type = result.CompiledAssembly.GetType("x.y");
        var instance = Activator.CreateInstance(type);
        var method = type.GetMethod("z");
        var args = new List<object>();
        // assume any parameters are properties of the current object
        foreach (var p in method.GetParameters())
        {
            args.Add(this.GetType().GetProperty(p.Name));
        }
        method.Invoke(instance, args.ToArray());
    }
