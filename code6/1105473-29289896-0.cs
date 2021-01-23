    using (var db = Db4oFactory.OpenFile(config, "StudentDB"))
    {
        var query = (from StudentDB x in db
                     where x.SSN == ssn
                     select x).SingleOrDefault();
         if (query != null)
         {
            db.Delete(query);
         }
         db.Commit();
    }
