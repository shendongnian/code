    var data = (from c in dbContext.Contacts
                          select new
                            {
                                c.Id,
                                TheirTime =EntityFunctions.AddHours(DateTime.UtcNow,c.TimezoneOffset)
                         })
