    namespace MyProject.Classes
    {
        public class CustomRoleProvider : RoleProvider
        {
            private MyEntities db;
    
            public override string[] GetRolesForUser(string username)
            {
                db = new MyEntities();
                tblOperator _tblOperator = (from prod in db.tblOperators
                                            where prod.Username == username
                                            select prod).FirstOrDefault();
    
                var roles = _tblOperator.tblOperatorRights.Where(m => m.WorkCentreID == 1).ToArray();
    
                return roles.Select(m => m.tblRight.RightName).ToArray();
            }
        }
    }
