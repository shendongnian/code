                try
                {
                    //code
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    string rs = "";
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        Console.WriteLine(rs);
    
                        foreach (var ve in eve.ValidationErrors)
                        {
                            rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw new Exception(rs);
                }
