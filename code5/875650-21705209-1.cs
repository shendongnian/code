    private static bool CheckAccessCodeExists()
        {
            using (EPOSEntities db = new EPOSEntities())
            {
                var item = db.ClientAccountAccesses.FirstOrDefault();
                if(item != null)
                {
                   db.Remove(item);
                   db.SaveChanges(); 
                   return true;                 
                }
                return false;
            }
        }
