    var userModels = var users = db.Users.Include(u => u.Tags)
                         .OrderByDescending(u => u.DimensaoRede)
                         .Take(5)
                         .Select(u => new UserModel {
                                      id = u.UserId,
                                      AdvanceLevel = u.AdvanceLevel,
                                      DimensaoRede = u.DimensaoRede,
                                      FortalezaRede = u.FortalezaRede,
                                      NormalLevel= u.NormalLevel,
                                      UserName = u.UserName,
                                      Facebook = u.Facebook != null ? u.Facebook : null,
                                      LinkedDin = u.LinkedDin != null ? u.LinkedDin : null,
                                      Status = u.Status  != null ? u.Status  : null,
                                      Nome = u.Nome != null ? u.Nome : null,
                                      Tags = u.Tags.Select(s => s.Nome).ToList()
                                   }).ToList();
