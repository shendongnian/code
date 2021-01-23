    var connString = @"server=x;database=x";
    using(var db = new MyContext(connString))
    {
        // ToString() shows the generated SQL string.
        var sql = db.Entities.Where(generatedExpression).ToString();
        Assert.IsTrue(sql.StartsWith("SELECT");
    }
