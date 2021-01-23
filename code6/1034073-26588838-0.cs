    using System.Diagnostics;
    
    ...
    
    Stopwatch stopWatch = new Stopwatch();
    
    stopWatch.Start();
    
    var userId = Int32.Parse(User.Identity.GetUserId());
      using (var context = new IdentityContext())
      {
          roleId = context.Database.SqlQuery<int>("SELECT RoleId FROM AspNetUserRoles where UserId = " + userId).FirstOrDefault();
      }
    
    stopWatch.Stop();
    
    TimeSpan ts = stopWatch.Elapsed;
    
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
