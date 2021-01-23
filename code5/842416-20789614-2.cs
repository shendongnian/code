    List<Tuple<string, int> >students = new List<Tuple<string, int> >();
    ...
    for (int i = 0; i < studentcount; i++)
    {
        Console.WriteLine("Enter students name: ");
        studentname = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Enter students score: ");
        x = Convert.ToInt32(Console.ReadLine()); 
        students.Add(studentname, x);
    }
    int max = students.Max(a => a.Item2).FirstorDefault();
