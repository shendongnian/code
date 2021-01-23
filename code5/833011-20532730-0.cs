 
    string userId = User.Identity.Name.ToLower();
    var owner = db.TaskOwners
      .Include(x => x.DirectReports)
      .Where(x => x.UserId == userId ).First();
     
