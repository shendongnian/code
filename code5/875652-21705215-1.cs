    if (db.ClientAccountAccesses.Any())
    {
      db.DeleteObject(db.ClientAccountAccesses.First());
    }  
 
    private static bool CheckAccessCodeExists()
        {
            using (EPOSEntities db = new EPOSEntities())
            {
                var obj = db.ClientAccountAccesses.FirstOrDefault();
                if(obj!=null)
                {
                   db.DeleteObject(obj);
                   return true;
                }               
            }
            return false;
        }
    
