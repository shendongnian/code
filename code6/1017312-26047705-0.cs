            var q = from p in db.CustomUserProfiles
                    join a in db.AllowedCompanies on new { ID = p.ID } equals new { ID = a.CustomUserProfileID }
                    join c in db.ReportingCompanies1 on new { ReportingCompanyID = (int)(int)a.ReportingCompanyID } equals new { ReportingCompanyID = c.ID }
                    join f in db.FavoriteClients
                          on new { a.CustomUserProfileUserId, ReportingCompanyID = a.ReportingCompanyID }
                  equals new { CustomUserProfileUserId = (Guid)f.Userid, ReportingCompanyID = f.CompanyId } into FavoriteClients_join
                    from FavoriteClients in FavoriteClients_join.DefaultIfEmpty()
                    where
                        p.UserName == userName
                    orderby
                        FavoriteClients.VisitCount descending, 
                        c.CompanyName
                    select new Clients()
                    {
                        ID = c.ID,
                        CompanyId = c.CompanyId,
                        CompanyName = c.CompanyName,
                        visitCount = ((Int32?)FavoriteClients.VisitCount ?? (Int32)0)
                    };
