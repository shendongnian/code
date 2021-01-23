    var res = (from r in result
                           join r2 in result2 on new { EmpId= r.EmpId, Date = r.Date.Value.Year } equals new { EmpId= Convert.ToInt32(r2.EmpId), Date = r2.Date.Value.Year } into list
                           from l in list.DefaultIfEmpty()
                           select new
                           {
                               EmpId= r.EmpId,
    Date=r.Date,
    EmpName=r.EmpName,
    StudentId= (l != null) ? l.StudentId : (int?)null
    }).ToList();
