    private static bool CheckAccessCodeExists()
        {
            using (EPOSEntities db = new EPOSEntities())
            {
                return db.ClientAccountAccesses.FirstOrDefault()!=null;
            }
        }
    
