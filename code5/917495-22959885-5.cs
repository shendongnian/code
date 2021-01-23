    return Json(
        _db.People.OrderByDescending(p =>
                p.LastUpdated
            ).Select(p => 
                new
                {
                    ID = person.UserId,
                    Name = person.FullName,
                    Title = person.Title,
                    InOtherTable = _db.SomePeople2.Any(x=>x.UserId == p.UserId)
                }
            ).ToArray(),
        JsonRequestBehavior.AllowGet
    );
