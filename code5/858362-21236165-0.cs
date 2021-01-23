    var query = from s in dc.UserWebSites
                join zk in dc.ZeekUsers on s.aspnet_User.UserId equals zk.UserId
                where s.aspnet_User.LoweredUserName.Equals(strUsername.ToLower())
                orderby s.LastUpdate descending
                select new { Site = s, ZoneId = zk.TimeZoneID };
    // Do the rest of the query in-process, so we can use time zones.
    var results = (from pair in query.AsEnumerable()
                   let site = pair.Site
                   let zone = TimeZoneInfo.FindSystemTimeZoneById(pair.ZoneId)
                   select new UserWebSiteInfo {
                       // Select all your properties here
                   }).ToList();
