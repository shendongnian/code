        private static bool CheckAccessCodeExists()
        {
            using (EPOSEntities db = new EPOSEntities())
            {
                if (db.ClientAccountAccesses.Any())
                {
                    db.DeleteObject(db.ClientAccountAccesses.First());
                    db.SaveChanges();
                    return true;
                }             
            }
            return false;
        }
    
