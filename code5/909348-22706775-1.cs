    var mock = new Mock<IDbSet<Setting>>();
    var myQueryable = Enumerable.Empty<Setting>().AsQueryable();
    mock.Setup(m => m.Provider).Returns(myQueryable.Provider);
    mock.Setup(m => m.Expression).Returns(myQueryable.Expression);
    mock.Setup(m => m.GetEnumerator()).Returns(myQueryable.GetEnumerator());
    var count = mock.Object.Count();
