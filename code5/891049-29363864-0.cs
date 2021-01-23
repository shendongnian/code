    var db1 =  db.Tables
            .Where(_ => _.Column == 'SomeRandomValue'
                && _.Column2 == 'AnotherRandomeValue').AsEnumerable().ToList();
    db.Tables.RemoveRange(db1);
    db.SaveChanges();
