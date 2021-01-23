    using (var db = new ProjectContext())
    {           
        foreach (var item in MyProject.Brands)
        {
            var found = db.Brands.FirstOrdefault(i => i.Name == item.Name);
            if (found == null)
            {
               // Add
               db.Brands.Add(item);
            }
            else
            {
               // Update
               found.prop1 = item.prop1;
               found.prop2 = item.prop2;
               // ... etc, for all and any updatable properties
            }
        }
        db.SaveChangesAsync();
    }
