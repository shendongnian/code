    EntityInstance_ReviewEntities.GetContext(GetConnectionString(ClientId));
    private string GetConnectionString(int TenantId)
            {
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                ISecurityRepository objSecurity = new SecurityRepository();
                string tenantConnectionString = objSecurity.GetClientConnectionString(TenantId);
                entityBuilder.ProviderConnectionString = tenantConnectionString;
                entityBuilder.Provider = "System.Data.SqlClient";
                entityBuilder.Metadata = @"res://*/ClientEntity.YourEntity.csdl|res://*/ClientEntity.ADBClientEntity.ssdl|res://*/ClientEntity.YourEntity.msl";
                return entityBuilder.ToString();
            }
