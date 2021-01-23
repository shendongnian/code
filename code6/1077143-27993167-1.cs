    var mids = _db.Members
             .Where(m => m.CreatedDate.Date == DateTime.Today)
             .GroupBy(m => m.MemberID)
             .Where(m => m.All(s => s.Status == 1))
             .Select(
                group => new
                {
                    MID = group.Key
                }).ToList();
