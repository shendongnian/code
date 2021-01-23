    protected override void OnCreate(Bundle bundle)
    {
        .....
        if (this.Intent.Extras.ContainsKey("RootData"))
        {
            var rootData = (RootObject)this.Intent.Extras.Get("RootData");
        }
    }
