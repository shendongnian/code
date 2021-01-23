    public class CustomerMapFactory
        {
                private Type[] _mapTypes;
                public CustomerMapFactory()
                {
                    LoadAvailableMaps();
                }
                //Return a newly created Type
                public IXmlMapper CreateInstance(string customerId)
                {
                    var t = GetTypeToCreate(customerId);
                    if (t == null) throw new Exception("Customer map not found");
                    return Activator.CreateInstance(t) as IXmlMapper;
                }
            
                //Find the map to instantiate
                Type GetTypeToCreate(string customerId)
                {
                    return _mapTypes.FirstOrDefault(tpMap => tpMap.Name.Contains(customerId));
                }
                //Identify all Types that use the IXmlMapper
                private void LoadAvailableMaps()
                {
                    _mapTypes = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(t => t.GetInterface(typeof(IXmlMapper).ToString()) != null)
                                        .ToArray();
                }
            }
        }
