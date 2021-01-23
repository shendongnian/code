    var list = new[] 
    { 
        new MyObject { Property = "A" },
        new MyObject { Property = "B" }
    };
    var setMock = new Mock<DbSet<MyObject>>();
    setMock.Setup(m => m.SqlQuery(It.IsAny<string>(), It.IsAny<object[]>()))
        .Returns<string, object[]>((sql, param) => 
        {
            // Filters by property.
            var filteredList = param.Length == 1 
                ? list.Where(x => x.Property == param[0] as string) 
                : list;
            var sqlQueryMock = new Mock<DbSqlQuery<MyObject>>();
            sqlQueryMock.Setup(m => m.AsNoTracking())
                .Returns(sqlQueryMock.Object);
            sqlQueryMock.Setup(m => m.GetEnumerator())
                .Returns(filteredList.GetEnumerator());
            return sqlQueryMock.Object;
        });
    var contextMock = new Mock<MyDbContext>();
    contextMock.Setup(m => m.Set<MyObject>()).Returns(setMock.Object);
