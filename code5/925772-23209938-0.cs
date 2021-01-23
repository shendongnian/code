       var an = (from a in db.Info  
              from b in db.Contact.Where(b => b.InfoID == a.ID && b.ContactTypeID == 56 && b.LogicalDelete == false).DefaultIfEmpty()
              from c in db.Contact.Where(c => c.InfoID == a.ID && c.ContactTypeID == 59 && c.LogicalDelete == false).DefaultIfEmpty()           
              where 
              select new
              {
                  a.ID,
                  a.LastName,
                  a.FirstName,
                  a.MiddleName,
                  Email = b==null? "" : b.Values,
                  Cellphone = c==null? "" : c.Values,
              }).ToList();
