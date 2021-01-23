        var assembly = System.Reflection.Assembly.LoadFrom(file);
                    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;
                    var derivedAssemblies = assembly.GetExportedTypes().Where(w => w.IsSubclassOf(typeof(AddressManager.Base.Connector.ConnectorBase))).Count(); 
                    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= CurrentDomain_ReflectionOnlyAssemblyResolve;
                    assembly = null;
                    if (derivedAssemblies > 0)
                    {
                        Manager.LoadAssembly(file, "Connectors");
                        Trace.TraceInformation(" Success! Library loaded.");
                    }
                    else
                        Trace.TraceInformation(" Skipped! Not a subclass of '" + typeof(AddressManager.Base.Connector.ConnectorBase).Name + "'.");
