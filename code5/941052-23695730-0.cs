    var counts =
                    _db.Departments.
                        .Select(c => new {key = 1, count = 0})
                        .Union(_db.Students.Select(c => new {key = 2, count= 0}))
                        .GroupBy(c=>c.key)                  
                        .Select(x => new CountsVm()
                        {
                            DepartmentCount = x.Count(d => d.key == 1),
                            StudentCount = x.Count(s => s.key == 2)
                        }).FirstOrDefault();
    
    
    
    public class CountsVm
        {
            public int StudentCount { get; set; }
            public int DepartmentCount { get; set; }
        }
