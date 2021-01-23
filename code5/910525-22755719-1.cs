    [HttpPost]
            public JsonResult userdelete(UserProfile user, int userId)
            {
                try
                {
                    var usersC = from x in _db.UserProfiles where x.UserId == user.UserId select x;
                    var UserToUpdate = usersC.First();
                    UserToUpdate.UserId = user.UserId;
                    UserToUpdate.UserName = user.UserName;
                    UserToUpdate.IdentificationNumber = user.IdentificationNumber;
                    UserToUpdate.department = user.department;
                    _db.UserProfiles.Remove(UserToUpdate);
                    _db.SaveChanges();
                    return Json(new { Result = "OK" });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
