    var studentData = (from redt in RoundEndDateTable.AsEnumerable()
                 join st in StudentTable.AsEnumerable() on redt["ActionName"] equals st["ActionName"]
                 select new
                 {
                     PlayerId = (int)st["PlayerId"],
                     ActionName = (string)st["ActionName"],
                     Completed = (DateTime)st["Completed"],
                     Date = (DateTime)redt["Date"]
                 })
                 .Select(sd => new {
                     sd.PlayerId,
                     sd.ActionName,
                     (sd.Completed - sd.Date).TotalDays
                 })
                 .ToList();
