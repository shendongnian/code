    var query = from a in dbContext.TableA
                join b in dbContext.TableB on new { a.Id, a.Name } equals new { b.Id, b.Name }
                join c in dbContext.TableC on b.Id equals c.Id
                join d in dbContext.TableD on new { c.Id, c.Occupation } equals new { d.Id, d.Occupation }
                select new
                {
                    AId = a.Id,
                    BId = b.Id,
                    CId = c.Id,
                    DId = d.Id,
                    BName = b.Name,
                    DOccupation = d.Occupation,
                };
