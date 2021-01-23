    [Test]
    public void CanUseIncludeWithMocks()
    {
        var child = new Child();
        var parent = new Parent();
        parent.Children.Add(child);
        var parents = new List<Parent> { parent };
        var children = new List<Child> { child };
        var parentsDbSet1 = new FakeDbSet<Parent>();
        parentsDbSet1.SetData(parents);
        var parentsDbSet2 = new FakeDbSet<Parent>();
        parentsDbSet2.SetData(parents);
        parentsDbSet1.Setup(x => x.Include(It.IsAny<string>())).Returns(parentsDbSet2.Object);
        // Can now test a method that does something like: context.Set<Parent>().Include("Children") etc
    }
    public class FakeDbSet<T> : Mock<DbSet<T>> where T : class
    {
        public void SetData(IEnumerable<T> data)
        {
            var mockDataQueryable = data.AsQueryable();
            As<IQueryable<T>>().Setup(x => x.Provider).Returns(mockDataQueryable.Provider);
            As<IQueryable<T>>().Setup(x => x.Expression).Returns(mockDataQueryable.Expression);
            As<IQueryable<T>>().Setup(x => x.ElementType).Returns(mockDataQueryable.ElementType);
            As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(mockDataQueryable.GetEnumerator());
        }
    }
