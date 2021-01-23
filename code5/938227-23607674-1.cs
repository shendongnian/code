    ObjectFactory.Initialize(x => 
                    { x.Scan(
                          scan =>
                          {
                              scan.AssembliesFromPath(Environment.CurrentDirectory + @"\Impl" ); //location of assemblies with interfaces implementation
                              scan.WithDefaultConventions();
                          }
                        );
                    });
