     var query = from s in Schedules
                            join ss in Schedules on s.SessionID equals ss.SessionID
                            join c in ClientSessions on ss.SessionID equals c.SessionID
                            join l in Locations on s.LocationID equals l.LocationID
                            where s.CompanyID =  109  && s.LocationID = 4 && (s.ClassDate >= DateTime.Now.AddDays(-7))
                             group c by new
                            {
                                c.ClassDate,
                                l.LocationName 
                            } into gcs
                            select new  
                            {
                                ClassDate = gcs.Key.ClassDate,
                                LocationName = gcs.Key.LocationName,
                                SessionIDCount = gcs.c.Count()
                            };
