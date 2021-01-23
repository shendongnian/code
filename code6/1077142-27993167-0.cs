    var mids = _db.Members
             .GroupBy(m => new { m.MemberID, m.CreatedDate })
             .Where(m => m.All(s => s.Status == 1) && m.Key.CreatedDate.Date == DateTime.Today)
             .Select(
                group => new
                {
                    MID = group.Key
                }).ToList();
