    public static BundleConfig
    {
      public const string SiteScripts = "~/bundle/scripts/site";
      public const string SiteSytles = "~/bundle/styles/site";
      public const string Controller1View1Scripts = "~/bundle/scripts/controller1";
      public const string Controller1View1Sytles = "~/bundle/styles/controller1";
      public static void RegisterBundles(BundleCollection bundles)
      {
        BundleConfig.RegisterScripts(bundles);
        BundleConfig.RegisterStyles(bundles);
      }
      public static void RegisterScripts(bundles)
      {
        bundles.Add(new ScriptBundle(BundleConfig.SiteScripts).Include(
          "...",
          "..."
          ));
      }
      //.. the rest should be obvious from these examples
    }
