    var marksjoin = (from a in db.TbStudent
                             join b in db.TbMarks on a.StudentId equals b.StudentId
                             select new StudentType
                                 {
                                   StudentName = b.StudentName,
                                   StudentId =  b.StudentId,
                                   // etc
                                 }).ToList();
      public class StudentType {
       public string StudentName { get; set; }
       public int StudentId { get; set; }
       // etc...
     }
