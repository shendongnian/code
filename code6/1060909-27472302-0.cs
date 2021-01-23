    int id = 1;
        var db = new Project.Models.Context();
        var query1 = db.Users.Where(t => t.id == id);
        //here is where the problem starts
        IQueryable<Project.Models.test> test = query1.Join(db.Table2,
                    users => users.id,
                    table2 => table2.userId,
                    (users, table2) => new Project.Models.test()
                    {
                        columName1 = users.UserName,
                        columName2 = table2.SomeValue
                    });
