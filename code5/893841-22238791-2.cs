    List<dynamic> Students = new List<dynamic>() 
                                 { 
                                    new { Name = "A", Age = 28, Height = 175 }, 
                                    ...
                                 };
    var test = Students.GroupBy(x=> x.Age);
