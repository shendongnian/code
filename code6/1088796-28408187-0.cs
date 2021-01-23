    DismApi.Initialize(DismLogLevel.LogErrors);
    using (DismSession session = DismApi.OpenOnlineSession())
    {
        foreach (DismFeature feature in DismApi.GetFeatures(session))
        {
            Console.WriteLine(feature.FeatureName + ": " + feature.State);
        }
    }
    DismApi.Shutdown();
