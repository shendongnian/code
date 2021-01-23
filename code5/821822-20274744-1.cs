     public static void Update_User(Distributor updated)
     {
        using (BmEntities b = new BmEntities())
        {
            var curUser = b.Distributor.Where(k => k.ID == updated.ID).First();
            curUser.CopyPropertiesFrom(updated); 
            b.SaveChanges();
        }
    }
