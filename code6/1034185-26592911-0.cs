    using System.Data;
    
    SelectedHarmonyAttribute attribute;
    
    using (var db = new YourDbContext())
    {
        db.Entry(attribute).State = attribute.HarmonyAttribute_ID == 0 ? EntityState.Added : EntityState.Modified;
    
        db.SaveChanges();
    }
