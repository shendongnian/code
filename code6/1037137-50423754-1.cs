    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<WMRole>("RolesNormal"); 
            modelBuilder.EntitySet<WMCommon.DAL.EF.tROLE>("Roles").EntityType.HasKey(o => o.IDRole).HasMany(t => t.tROLE_AUTHORIZATION);
            modelBuilder.EntitySet<WMCommon.DAL.EF.tLOOKUP>("Lookups").EntityType.HasKey(o => o.IDLookup).HasMany(t => t.tROLE_AUTHORIZATION);
            modelBuilder.EntitySet<WMCommon.DAL.EF.tROLE_AUTHORIZATION>("RoleAuthorizations").EntityType.HasKey(o => o.IDRoleAuthorization);
            config.Routes.MapODataRoute("odata", "odata", modelBuilder.GetEdmModel());
            config.EnableQuerySupport();
        }
    }
    
