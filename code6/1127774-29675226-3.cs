    List<SqlGuid> c = a.Select(g => new SqlGuid(g)).ToList();
    c.Sort();
    Console.WriteLine("--Sorted SqlGuids 2--");
    foreach (SqlGuid sg2 in c)
    {
        Console.WriteLine("{0}", sg2);
    }
