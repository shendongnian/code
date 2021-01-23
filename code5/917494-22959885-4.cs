    foreach (var person in _db.People.OrderByDescending(p => p.LastUpdated))
    {
       data.Add(new List<string>
       {
            person.UserId,
            person.FullName,
            person.Title,
            (_db.SomePeople2.Any(x=>x.UserId == p.UserId) ? "Y" : "N")
        }    
    }
    return Json(data, JsonRequestBehavior.AllowGet);
