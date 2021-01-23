    protected override IEnumerable<Assembly> SelectAssemblies()
            {
                var assemblies = base.SelectAssemblies();
                
                //locate other dlls here, I do it in my app based on the namespace and extension
    
                return assemblies.Concat(modules);
    
            }
