    //the list sent to View             
    eventlist = (from m in db.tblEvents
                 where item.Equals(m.EventId)
                 select new tblEvent() //here
                 {
                     id = m.EventId,
                     caption = m.Caption,
                     description = m.Description,
                     date = m.Date.ToString()
                 }).ToList();
