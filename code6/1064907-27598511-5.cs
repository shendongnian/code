    var people = from line in File.ReadLines(path)
                 let parts = line.Split(delimiter)
                 select new Person {
                    Id = Int32.Parse(parts[0]),
                    Name = parts[1],
                    Salary = Decimal.Parse(parts[2])
                 };
                     
