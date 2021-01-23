    static void Main(string[] args)
    {
        var dt = new DataTable();
        dt.Columns.Add("Talk_Time", typeof(TimeSpan));
        for (var i = 0; i < 101; i++)
        {
            var dr = dt.NewRow();
            dr["Talk_Time"] = TimeSpan.FromDays(1);
            dt.Rows.Add(dr);
        }
        var sum = (TimeSpan)dt.Compute("Sum(Talk_Time)", "");
        Console.WriteLine("{0}:{1}:{2}", sum.TotalHours, sum.Minutes, sum.Seconds);
        Console.ReadKey();
    }
