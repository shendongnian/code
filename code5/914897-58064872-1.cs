      class Program
      {
        static void Main(string[] args)
        {
            var students = new Students();
            var orderedStudentses = students.GetStudentRecords()
               .GroupBy(grp => grp.GradePoint)
               .OrderByDescending(x => x.Key).Skip(2)
               .Take(1)
               .SelectMany(s => s)
               .ToList()
               .ForEach(p => 
               Console.WriteLine($"Id : {p.StudentId}, Name : {p.StudentName}, achieved Grade Point : {p.GradePoint} "));
        }
      }
