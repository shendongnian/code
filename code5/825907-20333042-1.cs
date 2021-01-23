    SortedDictionary<int, SortedDictionary<int, string>> classDictionary;
    
    classDictionary = File.ReadLines(schoolCSV)
       .Select(line => line.Split(','))
       .Select(data => new 
       { 
          ClassId = int.Parse(data[0]),
          StudentId = int.Parse(data[1]),
          StudentName = data[2]
       })
       .GroupBy(item => item.ClassId, (key, items) => new
       {
          ClassId = key,
          Students = items.ToSortedDictionary(i => i.StudentId, i => i.StudentName)
       })
       .ToSortedDictionary(item => item.ClassId, item => item.Students);
