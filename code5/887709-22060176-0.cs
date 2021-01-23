    private static void AddBundleConfiguration<T>(BundleCollection bundles, IEnumerable<BundleConfig> bundleConfigs)
        where T : IBundleTransform, new()
    {
        foreach (var bundleConfig in bundleConfigs)
        {
            // The bug WAS here; it was passing in null instead of an empty array, thus the
            // Bundle constructor params would have an array of one that contained a null.
            var transform = bundleConfig.Minify
                ? new IBundleTransform[] { new T() }
                : new IBundleTransform[0];
            var bundle = String.IsNullOrWhiteSpace(bundleConfig.CdnPath)
                ? new Bundle(bundleConfig.BundlePath, transform)
                : new Bundle(bundleConfig.BundlePath, bundleConfig.CdnPath, transform);
