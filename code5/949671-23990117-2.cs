    [TestMethod]
    public async Task GetAllRecordsAsyncTest()
    {
        var data = new List<TABLE_NAME>
        {
            new TABLE_NAME {VALID= 1, NAME = "test 1"},
            new TABLE_NAME {VALID= 1, NAME = "test 2"}
        }.AsQueryable();
        var mockSet = new Mock<DbSet<TABLE_NAME>>();
        mockSet.As<IQueryable<TABLE_NAME>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<TABLE_NAME>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<TABLE_NAME>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<TABLE_NAME>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        mockSet.As<IDbAsyncEnumerable<TABLE_NAME>>().Setup(x=>x.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<TABLE_NAME>(data.GetEnumerator()));
        var mockContext = new Mock<IDbContext>();
        mockContext.Setup(x => x.TABLE_NAME).Returns(mockSet.Object);
        var database = new Database();
        var records = await database.GetAllRecordsAsync<TABLE_NAME>(mockContext.Object);
        int numberOfRecords = records.Count;
        Assert.AreEqual(2, numberOfRecords, "Wrong number of records.");
    }
