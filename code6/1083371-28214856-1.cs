    public override void Initialize() {
       CreatableTypes()
            .EndingWith("Service")
            .AsTypes()
            .RegisterAsSingleton();
    }
