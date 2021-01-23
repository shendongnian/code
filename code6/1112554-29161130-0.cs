    var result = conn.tbl_users.Select(c=> new StoredProcedureEF_MVC.Models.User{
                        UserId  = c.UserId,
                        UserName = c.UserName, 
                        Email = c.Email
                  }).ToList();
      return View(result);
