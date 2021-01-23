    // db is my datacontext
    var groupByOS = (from c in
                          (from d in db.DeviceInfo 
                           where d.Os.ToUpper().Contains("ANDROID") ||
                           d.Os.ToUpper().Contains("IOS")
                           group d by new { d.Os } into dev
                           select new
                           {
                             User = dev.Key.Os.ToUpper().Contains("ANDROID") ? "Android" : "iOS",
                             DeviceCount = dev.Count()
                           })
                     group c by new { c.User } into newgrp
                     select new
                     {
                         newgrp.Key.User,
                         Count = newgrp.Sum(q => q.DeviceCount)
                     }).ToList();
