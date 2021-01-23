            IWindsorContainer container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(
                Component.For<IComponentThatNeedsAnArrayOfDecorators>()
                    .ImplementedBy<DecoratedComponent>());
            container.Resolve<IComponentThatNeedsAnArrayOfDecorators>();
