    using (var db = new FIXEntities())
    {
       db.Database.Log = x => Debug.WriteLine(x);
       var organizationDto = db.Organizations.First();
       var contactDto = organizationDto.Contacts.Last();
       //organizationDto.Contacts.Remove(contactDto); // not necessary
       
       db.Entry(contactDto).State = EntityState.Deleted;
    
       db.SaveChanges();
    }
