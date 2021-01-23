    var list = GetStudents();  // gets full list of students from somewhere, ordered by age, then name
    var subList = new List<Student>();  // creates new empty list of students.
    
    var ageList = list.Select(s => s.Age).Distinct().ToList();  // Gets a list of distinct age values
    ageList.ForEach(s => subList.Add(list.First(p => p.Age == s)));
