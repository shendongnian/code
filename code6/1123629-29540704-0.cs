    var query =  (from S in db.Students
                 where S.ID = ID
                 select new { 
                     S.EMAIL, 
                     S.NAME })
                 .AsEnumerable()
                 .Select(x => new {
                      EMAIL = x.EMAIL.Split('@')[0].Replace(".", " ,"), 
                      NAME = x.NAME});
