    class Bindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<StateClass>().ToSelf().InSingletonScope();
            Kernel.Bind<IListener>().ToMethod(ctx => ctx.Kernel.Get<StateClass>());
            Kernel.Bind<IState>().ToMethod(ctx => ctx.Kernel.Get<StateClass>());
        }
    }
