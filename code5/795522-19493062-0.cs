    (from c in classList
    join s in sessionList on c.ClassID equals s.ClassID
    select new
    {
        ID = c.ClassID,
        Name = c.Name,
        SessionList = s.SessionList
    })
    .SelectMany(e => e.SessionList.Select(s => new
    {
        ID = e.ClassID,
        Name = e.Name,
        Session = s
    }))
