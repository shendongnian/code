    static void Main(string[] args)
    {
        var dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Value1");
        dt.Columns.Add("Value2");
    
        var rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < 100000; i++)
        {
            var dr = dt.NewRow();
            dr[0] = rnd.Next(1, 1000);
            dr[1] = rnd.Next(1, 1000);
            dr[2] = rnd.Next(1, 1000);
            dt.Rows.Add(dr);
        }
    
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var duplicates = GetDuplicateRows(dt, "Id", "Value1", "Value2");
        sw.Stop();
        Console.WriteLine(
            "Found {0} duplicates in {1} miliseconds.", 
            duplicates.Count,
            sw.ElapsedMilliseconds);        
        Console.ReadKey();
    }
    
