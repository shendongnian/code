    List<INV_Types> invTypes = getTypes();
    invTypes.ForEach(s => context.INV_Types.Add(s));
    context.INV_Types.AddRange(invTypes);
    List<INV_Vendors> invVendors = getVendors();
    context.INV_Vendors.AddRange(invVendors);
    
    context.SaveChanges();
    
    List<INV_Assets> invAssets = getAssets();
    context.INV_Assets.AddRange(invAssets);
    
    context.SaveChanges();
