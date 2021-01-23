    using (var db = new DbContext())
    {
        var results = (from u in db.AspNetUserses
            join upi in db.UserPersonalInfoes on u.Id equals upi.UserId into upis
            from upi in upis.DefaultIfEmpty()
            join up in db.UserPreferenceses on u.Id equals up.UserId into ups
            from up in ups.DefaultIfEmpty()
                   join us in db.UserStatses on u.Id equals us.UserId into uss
                   from us in uss.DefaultIfEmpty()
            select new
            {
                Username = u.UserName,
                Telephone = (upi == null ? String.Empty : upi.Telephone),
                ID = u.Id,
                LastLogin = (us == null ? DateTime.MinValue : us.LastLoginDate) 
            }).ToList();
           var list = (from r in results
                       select new {
                         Username = r.UserName,
                         Telephone = r.Telephone,
                         ID = r.ID
                         LastLogin = r.LastLogin == DateTime.MinValue ? "" : r.LastLogin.ToString()
                        }).ToList();
   
          gvUsers.DataSource = list;
          gvUsers.DataBind();
    }
