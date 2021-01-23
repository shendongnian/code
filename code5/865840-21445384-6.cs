    var result = provider.CompileAssemblyFromSource(new CompilerParameters(), src);
    if (result.Errors.Count == 0)
    {
        var type = result.CompiledAssembly.GetType("x.y");
        var instance = Activator.CreateInstance(type);
        var method = type.GetMethod("z");
        var args = new List<object>();
        // assume any parameters are properties/fields of the current object
        foreach (var p in method.GetParameters())
        {
            var prop = this.GetType().GetProperty(p.Name);
            var field = this.GetType().GetField(p.Name);
            if (prop != null)
                args.Add(prop.GetValue(this, null));
            else if (field != null);
                args.Add(field.GetValue(this));
            else
                throw new InvalidOperationException("Parameter " + p.Name + " is not found");
        }
        method.Invoke(instance, args.ToArray());
    }
