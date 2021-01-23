    var people = new List<Student>();
    people.Add(new Student("Maria", "Svensson", "1989-06-14", "C#Programming", 7));
    people.Add(new Student("Bahar", "Nasri", "1992-08-04", "C#Programming", 5));
    people.Add(new Student("Kent", "Kaarik", "1967-12-12", "Software Development", 8));
    people.Add(new Student("Ahmed", "Khatib", "1990-06-06", "C#Programming", 9));
    people.Add(new Student("Lisa", "Lundin", "1984-01-22", "Software Development", 6));
    people.Add(new Student("Peter", "Stark", "1987-08-24", "Software Development", 4));
    people.Add(new Student("Christer", "Stefansson", "1987-04-02", "C#Programming", 10));
        
    var orderedPeople = people.OrderBy(x => x.Name);
    foreach (Student item in orderedPeople)
    {
       Console.WriteLine(item.firstN + " " + item.lastN + " " + item.birthD + " " + item.courseT + " " + item.gradeH);
    }
