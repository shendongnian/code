    var users = (from r in db.Records
                 where r.Form.CompetitionID == cID
                 group r by r.Nickname into g
                 let position = g.Count()
                 orderby position descending, g.Max(r => r.DateAdded)
                 select new TopUserModel {
                     Nickname = g.Key,
                     Position = position
                 }).Take(100).ToList();
