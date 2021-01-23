    db.GroupContacts.GroupBy(r => r.Name)
                    .Select(group => new GroupEmailRecipients() 
                        { GroupName = group.Key, 
                          EmailRecipients = group.Select(x => new EmailRecipient()
                              { 
                                FirstName = x.FirstName, 
                                LastName = x.LastName, 
                                Email = x.Email 
                              })
					    });
                   
