    public class TenantService : Service
    {
        public object Post(TenantRequest req)
        {
            db.Insert(new Tenant { CreatedDate = DateTime.Now }.PopulateWith(req));
            return new { Id = db.GetLastInsertId() };
        }
    }
