    protected void GetRoles(int UserID)
        {
            var db = new ResearchSurveysEntities();
            string[] getRoles = { };
            try
            {
                var query =
                    from p in db.UserProfiles
                    join i in db.webpages_UsersInRoles on p.UserId equals i.UserId
                    join r in db.webpages_Roles on i.RoleId equals r.RoleId
                    where p.UserId == UserID
                    select new { p.UserId, r.RoleName };
                if (query.Count() > 0)
                {
                    List<string> gRoles = new List<string>();
                    foreach (var item in query)
                    {
                        gRoles.Add(item.RoleName);
                    }
                    getRoles = gRoles.ToArray();
                }
                roles = String.Join("|", getRoles);
            }
            catch (Exception ex)
            {
                WebUtilities wu = new WebUtilities();
                wu.NotifyWebmaster(ex.ToString(), "Get roles for AdminUserID: " + UserID.ToString(), string.Empty, "Login Error");
            }
            finally
            {
                db.Dispose();
            }
        }
