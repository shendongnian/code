    public static void RequestNavigate<TView>(this IRegion region)
    {
        region.RequestNavigate(new Uri(typeof (TView).FullName, UriKind.Relative));
    }
    public static void RequestNavigate<TView>(this IRegionManager region, string regionName)
    {
        region.RequestNavigate(regionName, new Uri(typeof (TView).FullName, UriKind.Relative));
    }
