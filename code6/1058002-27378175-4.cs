    var results = 
    (from c in db.Colleges // db is your DataContext                               
    select new
    {
     CollegeName = c.Name,
     AcceptedStatus = db.Students.Count(r => r.Status.ToUpper() == "ACCEPTED" && (r.UniversityId == c.Id || r.CurrentCollege == c.Name)),
     WebAppStatus = db.Students.Count(r => r.Status.ToUpper() == "WEBAPP" && (r.UniversityId== c.Id || r.CurrentCollege == c.Name)),
     Total = db.Students.Count(s => s.UniversityId == c.Id || s.CurrentCollege == c.Name)
    }).ToList();
