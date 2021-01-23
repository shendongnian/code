    FindAndDeleteUnusedAddresses(Person person) {
     using (var db = new Entities())
                {
                    var personCount = db.Persons.Where(p => p.Address == person.Address).Count();
                    var businessCount = db.Businesses.Where(b => b.Address == person.Address).Count();
                    // other objects that have addresses here
    
                    if (personCount + businessCount == 0) // others included as necessary
                    {
                        db.Entry(person.Address).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
    }
