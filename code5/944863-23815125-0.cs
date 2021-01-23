    var source = new List<Test> { new Test { Id = 1, Name = "FirsT" }, new Test { Id = 2, Name = "Second" } };
    var idName = "Id";
    var idValue = 1;
    var param = Expression.Parameter(typeof(Test));
    var condition =
        Expression.Lambda<Func<Test, bool>>(
            Expression.Equal(
                Expression.Property(param, idName),
                Expression.Constant(idValue, typeof(int))
            ),
            param
        ).Compile(); // for LINQ to SQl/Entities skip Compile() call
    var item = source.SingleOrDefault(condition);
