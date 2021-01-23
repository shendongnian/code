      return (db.Persons
                .Where(x=> { 
                   var z = x.PersianBirthDate.Split("/".ToCharArray());
                   return (new DateTime(int.Parse(z[0]),int.Parse(z[1]),int.Parse(z[2])) <=
                           new DateTime(1362,1,1)); })
                .ToList();
