	foreach(var letter in li.GroupBy(l => l.name[0]).OrderBy(l => l.Key))
	{
        Console.WriteLine("Letter:" + letter.Key);
        foreach (var student in letter.GroupBy(l => l.name).OrderBy(l => l.Key)) 
        {
            Console.WriteLine(String.Format("\n\tKey: {0}", student.Key));
            foreach (var mark in student.OrderBy(s => s.marks)) 
                Console.WriteLine(String.Format("\t\t{0}, {1}", mark.name, mark.marks));
        }
		Console.WriteLine();
    }
