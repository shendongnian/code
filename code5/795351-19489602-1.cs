    protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
    {
        registry.RegisterCustomBindingFactory<ImageView>(
                        "Alpha",
                        v=> new ImageViewAlphaTargetBinding (v) );
        base.FillTargetFactories(registry);
    }
