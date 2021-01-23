    public Providers AllProviders
    {
        get
        {
            if (this.allProviders == null) this.allProviders = Providers.Instance; // alternatively, do what Providers.Instance is actually doing
            return this.allProviders;
        }
    }
