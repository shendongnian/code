    var supRole = iuserrepository.GetList(x => x.UserId != null && 
                                          userIds.Contains(x.UserId))
                                 .Select(x => new Supervisors
                                  {
                                      UserId = x.UserId,
                                     UserName = x.UserName 
                                  });
