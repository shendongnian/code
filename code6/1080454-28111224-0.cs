    Random rand = new Random();
    var set= new HashSet<int>();
    for (int i = 0; i < 20000; i++)
        set.Add(rand.Next(550000));
    Stopwatch watch = new Stopwatch();
    watch.Start();
    var sql = "SELECT * FROM [MyDb].[dbo].[MyEntities]";
    var result = context.Set<MyEntity>()
                 .SqlQuery(sql)
                 .AsEnumerable()
                 .Where(x => !set.Contains(x.ID))
                 .ToList();
    watch.Stop();
