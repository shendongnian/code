     public List<Provider> GetListofProviders()
        {
            List<Provider> Providers = new List<Provider>();
            using (_dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoApplicationConnection"].ConnectionString))
            {
                try
                {
                    Providers = _dbConnection.Query<Provider,ProviderDetails,Provider>("spGetAllProviders",null,splitOn: "ProviderId", commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            return Providers;
        }
