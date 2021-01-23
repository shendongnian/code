    return (from TT in _er.TimeTables
            where TT.Startdate == CoeStartdate
            select new  
            {
                CStartdate = TT.Startdate.Value.ToString() ,
                TimeTableID = TT.TimeTableID 
            }
            ).AsQueryable()
             .Select(x=> new Class_CourseStartdate
             {
                 CStartdate = x.CStartdate.Value.ToString(),
                 TimeTableID = x.TimeTableID
             }).ToLIst();
