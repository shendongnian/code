        public static IBindingOnSyntax<T> RegisterEvents<T>(this IBindingOnSyntax<T> binding)
        {
            // todo check whether <T> implements the IHandle<> interface, if not throw exception
            return binding
                .OnActivation((ctx, instance) => ctx.Kernel.Get<EventAggregator>().Subscribe(instance));
        }
