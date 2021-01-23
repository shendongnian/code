        MPortalContext db=new MPortalContext();
        foreach (var item in _ModulID)
        {
            var validation = db.WebSite_PermissionDB.Where(x => x.UserID == _UserID && x.ModuleID == item).FirstOrDefault();
            db.WebSite_PermissionDB.Remove(validation);
            db.SaveChanges();
        }  
        return true;
