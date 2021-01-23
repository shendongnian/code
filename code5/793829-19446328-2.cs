        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<Thing>(
                            "SpecialBinding",
                            thing => new ThingMyPropertyTargetBinding (thing) );
            base.FillTargetFactories(registry);
        }
