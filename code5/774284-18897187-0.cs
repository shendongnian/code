    var sample = (from e in dataContext.tblA.Include("tblB")
                  where e.Active == true 
                        && e.DateA.Date >= DateTime.Today //Compare date part only
                        && e.DateB.TimeOfDay >= DateTime.Now.TimeOfDay //Time part only
                            select new 
                            {
                            ...
                            }).ToList();
