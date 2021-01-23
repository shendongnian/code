     var Students = new []{
        new { Name = "A", Age = 28, Height = 175 },
        new { Name = "B", Age = 29, Height = 176 },
        new { Name = "C", Age = 30, Height = 177 },
        new { Name = "D", Age = 31, Height = 178 },
        new { Name = "A", Age = 32, Height = 179 },
        new { Name = "E", Age = 33, Height = 180 },
        new { Name = "A", Age = 34, Height = 181 },
        new { Name = "F", Age = 35, Height = 182 },
        new { Name = "B", Age = 36, Height = 183 }
    }.ToList();
    
    var groupedStudents = Students.GroupBy(x=>x.Age);
