    private static Mock<DbSet<Document>> GetQueryableMockDocumentDbSet()
    {
        var data = new List<Document> { GetDocument(111, 11), GetDocument(222, 22), GetDocument(333, 33) };
        var mockDocumentDbSet = new Mock<DbSet<Document>>();
        mockDocumentDbSet.As<IQueryable<Document>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
        mockDocumentDbSet.As<IQueryable<Document>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
        mockDocumentDbSet.As<IQueryable<Document>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
        mockDocumentDbSet.As<IQueryable<Document>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        mockDocumentDbSet.Setup(m => m.Add(It.IsAny<Document>())).Callback<Document>(data.Add);
        return mockDocumentDbSet;
