    var studentData = from redt in RoundEndDateTable
                 join st in StudentTable on redt.ActionName equals st.ActionName
                 select new
    {
        st.PlayerId,
        st.ActionName,
        ((DateTime)st.Completed - (DateTime)redt.Date).TotalDays
    }.ToList();
