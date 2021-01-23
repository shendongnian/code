    var libs = kernel.GetAll<ILibrary>();
                foreach (var lib in libs)
                {
                    var configFilePath = lib.GetType().Assembly.GetName().Name+".dll.config";
                    var file = new FileInfo(configFilePath);
                    if (file.Exists)
                    {
                        var setup = new AppDomainSetup() { ConfigurationFile = file.FullName, ApplicationBase = AppDomain.CurrentDomain.BaseDirectory };
                        var domain = AppDomain.CreateDomain(lib.GetType().FullName, null, setup);
                        
                        domain.Load(lib.GetType().Assembly.FullName);
    
                        var instance = domain.CreateInstanceAndUnwrap(lib.GetType().Assembly.FullName, lib.GetType().FullName);
    
                        var method = lib.GetType().GetMethod("Execute");
    
                        method.Invoke(instance, null);
                    }
                    else
                    {
                        Console.WriteLine("Missing Config File");
                    }
                }
