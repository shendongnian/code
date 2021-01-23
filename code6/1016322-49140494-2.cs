            public Mock<DbSet<TestModel>> MockDbSet { get; }
            ....
            MockDbSet.Setup(x => x.SqlQuery(It.IsAny<string>))
                  .Returns<string,object[]>
                  ((sql, param) => 
                  {
                        var sqlQueryMock = MockHelper.CreateDbSqlQuery(Models);
                        
                        sqlQueryMock.Setup(x => x.AsNoTracking())
                          .Returns(sqlQueryMock.Object);
                        return sqlQueryMock.Object;
                    });
