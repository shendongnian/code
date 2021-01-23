    // this is just psuedo code. it belongs in the constructor. ymmv
    var loggedOnUser = Myself;
    var dbProvider = SomeDbProvider;
    var tenantRepository = new TenantRepository(loggedOnUser, dbProvider);
    
    // here's the Find call... easy peasy.
    var listOfAllTenants = tenantRepository.Find()
