    //bindings
    Bind<ICache>().ToMethod(ctx => FactoryMethods.CreateCache(
        ctx.Kernel.Get<IXXX>(),
        ctx.Kernel.Get<IYYY>()))
    .InSingletonScope()
    .Named(BindingNames.SHARED_CACHE);
    Bind<ICache>().ToMethod(ctx => FactoryMethods.CreateTwoTierCache(
        ctx.Kernel.Get<ICache>(BindingNames.SHARED_CACHE),
        ctx.Kernel.Get<IZZZ>()))
    .InSingletonScope();
    // cache users
    public class UsesSharedCache
    {
        public UsesSharedCache([Named(BindingNames.SHARED_CACHE)] ICache sharedCache)
        {
        }
    }
    public class UsesDefaultCache
    {
        public UsesDefaultCache(ICache defaultCache)
        {
        }
    }
