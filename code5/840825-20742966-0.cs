      using (var context = new MyDBEntities())
                    {
                        try
                        {
                            var user = (User)Session["EditedUser"];
                            context.Users.Attach(user);
                            context.ObjectStateManager.ChangeObjectState(user, System.Data.EntityState.Modified);
                            context.SaveChanges();
                            Session["EditedUser"] = null;
                            return "ok";
                        }
                        catch (Exception ex)
                        {
    
                            return ex.Message;
                        }
                  }
