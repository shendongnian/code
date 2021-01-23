    XYZModel xyz = xyzDbContext.XYZModels.Find("xyzguid");
    
    xyzDbContext.Entry(xyz).State = EntityState.Detached;
    
    //modifying it
    xyz.AssociationId = xyz.Id;
    xyz.Id = Convert.ToString(Guid.NewGuid());
    xyz.Name = "New Name";
    
    //trying to add it as new entry
    xyzDbContext.XYZModels.Add(xyz);// No Error 
    xyzDbContext.SaveChanges();  
