    interface INDataAccessSoapClientFactory
    {
        NDataAccessSoapClient CreateClient();
    }
    class Lookup
    {
        private INDataAccessSoapClientFactory factory;
        public Lookup(INDataAccessSoapClientFactory factory)
        {
            this.factory = factory;
        }
        private ResultSetGetLookupMailingData()
        {
            try
            {
                using (var client = factory.CreateClient())
                {
                    var result = client.GetLookupData(XMLLookupDataTypes.xldtMailings, "");
                    return Deserialize<ResultSet>(result);
                }
            }
            catch (Exception)
            {
               return new ResultSet();
            }
        }
    }
