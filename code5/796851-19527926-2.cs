    var senderUA = session
                        .Query<UserAlert>()
                        .Where(x=>x.EntityId==id && 
                             x.UserAlertId==session.Query<UserAlert>()
                                               .Where(x=>x.EntiryId==id).Max(x=>x.UserAlertId)
                              ).FirstOrDefault();
