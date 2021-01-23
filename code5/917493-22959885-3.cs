    foreach (var person in _db.People.OrderByDescending(p => p.LastUpdated))
    {
       data.Add(new List<string>
       {
            person.UserId,
            person.FullName,
            person.Title,
            person.SomePeople2.Any() ? "Y" : "N"
        }    
    }
    return Json(data, JsonRequestBehavior.AllowGet);
