    if (item.Id > 0 && db.Entry(item).State == EntityState.Detached)
    {
        db.Entry(item).State = EntityState.Modified;
        db.SaveChanges();
    }
    else
    {
        db.CompanyTelephones.Add(item);
    }
