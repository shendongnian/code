    var studentData = (from redt in RoundEndDateTable
                 join st in StudentTable on redt.ActionName equals st.ActionName
                 select new
                 {
                     st.PlayerId,
                     st.ActionName,
                     st.Completed,
                     redt.Date
                 })
                 .ToList()
                 .Select(sd => new {
                     sd.PlayerId,
                     sd.ActionName,
                     (sd.Completed - sd.Date).TotalDays
                 })
                 .ToList();
