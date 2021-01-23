    SortedList<int> students = new SortedList<int>();
    ...
    for (int i = 0; i < studentcount; i++)
    {
        Console.WriteLine("Enter students name: ");
        studentname = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Enter students score: ");
        x = Convert.ToInt32(Console.ReadLine()); 
        students.Add(x);
    }
    int max = students.Last; //Default sorting is low to high, 
                             //though this could be changed if 
                             //you want to look into it.
