    public void StudentCount()
    {
        var students = new Dictionary<string, int>();
        var count = Convert.ToInt32(Console.ReadLine());
        for (var i = 0; i < count; i++)
        {
             Console.WriteLine("Enter Student's Name:");
             var name = Console.ReadLine();
             Console.WriteLine("Enter Student's Score:");
             var score = Convert.ToInt32(Console.ReadLine());
    
             students.Add(name, score);
        }
        var highestStudent = students.Max();
        Console.WriteLine("{0} scored {1}", highestStudent.Key, highestStudent.Value);
    }
