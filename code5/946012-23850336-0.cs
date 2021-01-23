    Console.WriteLine("Enter 5 Grades; Whole Integers Only, 0-100; One Space Between Grades");
    string[] splitgrades = Console.ReadLine().Split();
    
    g1.Name = name + "'s GradeBook";
    Console.WriteLine(g1.Name);
    Console.WriteLine("Press Any Key to Calculate Gradebook Statistics");
    Console.ReadKey();
    GradeBook book = new GradeBook();
    
    book.AddGrade(Int32.Parse(splitgrades[0]));
    book.AddGrade(Int32.Parse(splitgrades[1]));
