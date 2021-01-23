    var copies = new List<Student>();
    
    foreach (var item in studentData)
    {
        if(item.Section == 90)
        {
            var copy = new Student();
            copy.ID = item.ID;
            copy.Name = item.Name;
            copy.Marks = item.Marks;
            copy.Section = // your updates to section
            copies.Add(copy);
        }
    }
    
    studentData.AddRange(copies);
