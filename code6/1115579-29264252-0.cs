    using System.Runtime.Caching;
    .....
    ObjectCache cache;
    List<Model.SignedContracts> allSignedContracts;
    .....
    
    cache = MemoryCache.Default;
                allSignedContracts = cache["signed_contracts"] as List<Model.SignedContracts>;
    
                if (allSignedContracts == null)
                {
                    allSignedContracts = new List<Model.SignedContracts>();
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1.0);
                    var result = (from contracts in new XPQuery<Model.SignedContracts>(uow) select contracts);
                    foreach (var item in result)
                    {
                        allSignedContracts.Add(item); 
                    }
                    cache.Add("signed_contracts",allSignedContracts,policy);
                    
                }
