            var container = new WindsorContainer();
            container.Register(Component.For<IBar>().ImplementedBy<Bar>().Named("CreepyBar"));
            container.Register(Component.For<IBar>().ImplementedBy<Bar>().Named("MegaBar"));
            container.Register(Component.For<IFoo>()
                .ImplementedBy<Foo>()
                .Named("MyFoo")
                .DynamicParameters(
                    (k, d) =>
                        d["allMyBars"] = new Dictionary<string, IBar>
                        {
                            {
                                "Bar1",
                                k.Resolve<IBar>("CreepyBar")
                            },
                            {
                                "Bar2",
                                k.Resolve<IBar>("MegaBar")
                            }
                        }));
            var verifyFoo= container.Resolve<IFoo>();
