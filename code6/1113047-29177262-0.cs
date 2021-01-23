    var groupEmails = db.GroupContacts
                .GroupBy(x => x.GroupName)
                .Select(x => new GroupEmailRecipients
                {
                    GroupName = x.Key,
                    EmailRecipients = x.Select(y => new EmailRecipient
                    {
                        Email = y.Email,
                        FirstName = y.FirstName,
                        LastName = y.LastName
                    }).ToList()
                }).ToList();
