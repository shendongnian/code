    [HttpPost]
            public JsonResult Userupdate(UserProfile user)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Json(new
                        {
                            Result = "ERROR",
                            Message = "Form is not valid! " +
                              "Please correct it and try again."
                        });
                    }
    
                    var usersC = from x in _db.UserProfiles where x.UserId == user.UserId select x;
                    var UserToUpdate = usersC.First();
                    UserToUpdate.UserId = user.UserId;
                    UserToUpdate.UserName = user.UserName;
                    UserToUpdate.IdentificationNumber = user.IdentificationNumber;
                    UserToUpdate.department = user.department;
                    _db.SaveChanges();
                                 
                    return Json(new { Result = "OK"});
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
