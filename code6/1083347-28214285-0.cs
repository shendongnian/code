                builder.RegisterType<Component>().WithParameters(new[] {
                            new ResolvedParameter((p,c) => p.Name == "serv",(p,c) => 
                                new List<ITerry>
                                {
                                    c.ResolveKeyed<IService>(Services.Svc1),
                                    c.ResolveKeyed<IService>(Services.Svc3),
                                    c.ResolveKeyed<IService>(Services.Svc8),
                                })
                });
