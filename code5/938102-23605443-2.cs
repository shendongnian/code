    public static TenantContext
    {
        public static Guid TenantId 
        { 
            get 
            { 
                return (Guid)HttpContext.Current.Items["__TenantID"];  
            }
        }
         public static string ConnectionString
         {
            get 
            { 
                return TenantConfigService.GetConnectionString(TenantId);  
            }
         }
    }
