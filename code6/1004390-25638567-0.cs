    DataRow[] result = table.Select("Id = 1");
    foreach (DataRow row in result)
    {
        if (row[0].Equals(indicater[0]))
        {
           //IsSelected
           row[1]=true;
           Console.WriteLine("{0}", row[0]);
        }
    }
