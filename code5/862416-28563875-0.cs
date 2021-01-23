    using (var db = new Entities())
                    {
                       
                        var temprc = _reg.GetUserByID(Convert.ToInt32(Session["LogedUserID"]));
                        temprc.PasswordConfirm = U.NewPassword;
                        db.Userregistrations.Attach(temprc);
                        db.Entry(temprc).Property(x => x.PasswordConfirm).IsModified = true;
                        db.SaveChanges();
    
                    }
       
