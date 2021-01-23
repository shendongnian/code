    public class SiteAdminAPIController : Controller
    {
        private readonly DataBaseContext _oDataBaseContext = new DataBaseContext();
        private DbContext _oDBContext;
    
        public SiteAdminAPIController()
        {
             _oDBContext = _oDataBaseContext.dbContext();
        }
    }
