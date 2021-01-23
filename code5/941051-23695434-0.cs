    var countsVm = new CountsVm(){
         DepartmentCount = 0,
         StudentCount = 0
    };
    var counts =
                    _db.Departments.All()
                        .Select(c => new {key = 1, count = 0})
                        .Union(_db.Students.All().Select(c => new {key = 2, count= 0}))
                        .GroupBy(c=>c.key)                  
                        .Select(x => {
                              countsVm.DepartmentCount += x.Count(d => d.key == 1);
                              countsVm.StudentCount += x.Count(s => s.key == 2);
                              return null;
                         });
    
    
    
    public class CountsVm
        {
            public int StudentCount { get; set; }
            public int DepartmentCount { get; set; }
        }
