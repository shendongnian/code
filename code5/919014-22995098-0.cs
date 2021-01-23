    var olddate = DateTime.MinValue;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        var newdate = DateTime.Parse(dt.Rows[i]["Date"].ToString());
        if (newdate != olddate)
        {
             Console.WriteLine();
             Console.WriteLine(newdate.ToShortDateString());
        }
        Console.WriteLine(dt.Rows[i]["News"].ToString());
        olddate = newdate;
     }
     Console.Read();
