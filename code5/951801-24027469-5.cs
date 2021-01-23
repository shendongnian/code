    private static ConcurrentDictionary<Territory, IList<Vendor>> _vendors = new ConcurrentDictionary<Territory, IList<Vendor>>();
    public static IList<Vendor> VendorList(IVendorService vendorSerice, Territory territory)
    {
      // We now have different lists of vendors for different countries, states, etc.
      // We were able to make all of our changes through this place, and keep a similar
      // type of caching happening.
      return _vendors.GetOrAdd(territory, () => vendorSerice.GetVendors(territory));
    }
