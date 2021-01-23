    public static class KernelExtensions
    {
        public static void BindComposite<TComposite, TCompositeElement>(this StandardKernel container) where TComposite : TCompositeElement
        {
            container.Bind(x => x.FromAssemblyContaining(typeof(TComposite))
                .SelectAllClasses()
                .InheritedFrom<TCompositeElement>()
                .Excluding<TComposite>()
                .BindAllInterfaces()
                .Configure(c => c.WhenInjectedInto<TComposite>()));
            container.Bind<TCompositeElement>().To<TComposite>()
              .When(IsNotCompositeTarget<TComposite>);
        }
        private static bool IsNotCompositeTarget<TComposite>(IRequest x)
        {
            if (x.Target == null)
                return true;
            return x.Target.Member.ReflectedType != typeof(TComposite);
        }
    }
