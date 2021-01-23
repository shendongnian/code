    var sendto = from businesscontact in db.businesscontacts.Include(bc => bc.contact)
                    select new {
                      businesscontact.contact.firstname,
                      businesscontact.contact.lastname
                    };
