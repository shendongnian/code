    var result = jquery.GroupBy(u => u.username)
                       .Select(x=> new UserGrade{
                           UserName = x.Key,
                           Grades = String.Join(",",x.Select(y=>y.Grade)
                     }).ToList();
