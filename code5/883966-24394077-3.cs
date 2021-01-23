    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void SomeTest()
    {
        //Setup
        var mockContext = new Mock<FakeDbContext>();
        //SomeClass can be abstract or concrete
        mockContext.createFakeDBSet<SomeClass>();
        var db = mockContext.Object;
        var list1 = db.Set<SomeClass>().ToList();
        //SomeOtherClass derived from SomeClass
        var subList1 = db.Set<SomeOtherClass>().ToList();
        CollectionAssert.AreEquivalent(list1.OfType<SomeOtherClass>.ToList(), subList1);
    }
