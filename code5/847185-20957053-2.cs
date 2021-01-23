    public partial class MyContext: DbContext
    {
        public MyContext(string efConnectionString):base(efConnectionString)
        {
    
        }
    
        public static MyContext CreateContextFromAdoCS(string adoConnectionString)
        {
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
    
            //Set the provider name.
            entityBuilder.Provider = "System.Data.SqlClient";
    
            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = adoConnectionString;
    
            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/MyModel.csdl|
                            res://*/MyModel.ssdl|
                            res://*/MyModel.msl";
            var efCs = entityBuilder.ToString();
    
            return new MyContext(efCs);
        }
    }
