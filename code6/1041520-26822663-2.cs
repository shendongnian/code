    public class AspNetQueryStringTenantContext : ITenantContext {
        public string TenantId {
            get { return HttpContext.Current.Request.QueryString["tenant"]; }
        }
    }
