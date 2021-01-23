    try
      {
        var NewSelectedUnitType = db.OrganizationalUnitType.SingleOrDefault(p=>p.ID == unitID);
        db.OrganizationalUnitType.Remove(NewSelectedUnitType);
        db.SaveChanges();
      }
     catch (Exception ex)
      {
         ..
      }
