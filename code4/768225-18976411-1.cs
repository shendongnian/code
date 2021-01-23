    public CeDbConfiguration()
    {
     SetDefaultConnectionFactory(new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName,
                                                            @"c:\test",
                                                            @"c:\test\db.sdf"));
    SetProviderServices(SqlCeProviderServices.ProviderInvariantName,
                        SqlCeProviderServices.Instance);
    }
