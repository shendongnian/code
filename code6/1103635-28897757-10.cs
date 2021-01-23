    // Queries that are NotSupportedException with LINQ-to-SQL
    var q1 = context.Items.AsSafe().Where(x => x.ID.GetHashCode() > 0).Take(2).Select(x => x.ID);
    var q2 = context.Items.Where(x => x.ID.GetHashCode() > 0).AsSafe().Take(2).Select(x => x.ID);
    var q3 = context.Items.Where(x => x.ID.GetHashCode() > 0).Take(2).AsSafe().Select(x => x.ID);
    var q4 = context.Items.Where(x => x.ID.GetHashCode() > 0).Take(2).Select(x => x.ID).AsSafe();
    //// Queries that are OK with LINQ-to-SQL
    //var q1 = context.Items.AsSafe().Where(x => x.ID > 0).Take(2).Select(x => x.ID);
    //var q2 = context.Items.Where(x => x.ID > 0).AsSafe().Take(2).Select(x => x.ID);
    //var q3 = context.Items.Where(x => x.ID > 0).Take(2).AsSafe().Select(x => x.ID);
    //var q4 = context.Items.Where(x => x.ID > 0).Take(2).Select(x => x.ID).AsSafe();
    var r1 = q1.ToList();
    var r2 = q2.First();
    var r3 = q3.Max();
    // The Aggregate isn't normally supported by LINQ-to-SQL
    var r4 = q4.Aggregate((x, y) => x + y);
    var ex1 = ((ISafeQueryable)q1).Exception;
    var ex2 = ((ISafeQueryable)q2).Exception;
    var ex3 = ((ISafeQueryable)q3).Exception;
    var ex4 = ((ISafeQueryable)q4).Exception;
