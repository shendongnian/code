    public class TenantService : Service
    {
        public object Post(TenantRequest req)
        {
            var tenant = new Tenant { CreatedDate = DateTime.Now }.PopulateWith(req);
            Db.Save(tenant);
            return new { Id = tenant.Id };
        }
    }
