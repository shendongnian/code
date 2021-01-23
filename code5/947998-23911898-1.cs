            ContainerBuilder cb = new ContainerBuilder();
            cb.RegisterType<SomeOtherType>();
            cb.RegisterType<SomeType>()
                .OnActivated(act => 
                { 
                    var other = act.Context.Resolve<SomeOtherType>(); 
                    act.Instance.Input += other.Output; 
                });
            var container = cb.Build();
            var obj2 = container.Resolve<SomeType>();
            obj2.Raise();
