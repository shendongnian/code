    public static void Configure(Action<HttpConfiguration> configurationCallback)
    {
        if (configurationCallback == null)
        {
            throw new ArgumentNullException("configurationCallback");
        }
        configurationCallback.Invoke(Configuration);
        Configuration.EnsureInitialized();
    }
