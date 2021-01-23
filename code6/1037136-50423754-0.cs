    public class RolesController : ODataController
    {
        private AngularCRMDBEntities db = new AngularCRMDBEntities();
        [Queryable]
        public IQueryable<tROLE> GetRoles()
        {
            return db.tROLEs;
        }
    }
