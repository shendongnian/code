    var sample = (from e in dataContext.tblA.Include("tblB")
                  where e.Active == true 
                        && EntityFunctions.TruncateTime(e.DateA) >= DateTime.Today //Compare date part only
                        && EntityFunctions.CreateTime(e.DateB.Hour, e.DateB.Minutes, e.DateB.Seconds) >= DateTime.Now.TimeOfDay //Time part only
                            select new 
                            {
                            ...
                            }).ToList();
