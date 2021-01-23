    using (ConsoleApplications.DataClasses1DataContext dd = new ConsoleApplications.DataClasses1DataContext())
    {
       var result = (from stu in dd.Students.AsEnumerable()
          select new
          {
           stu.StudentName,
           RandomId = new Random(DateTime.Now.Millisecond).Next(dd.Students.Count())
          }).OrderBy(s => s.RandomId);
    
          foreach (var item in result)
          {
            Console.WriteLine(item.StudentName);
          }
    }
