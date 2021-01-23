    public void GetAllBlogs_orders_by_name()
    {
      // Arrange
      var data = new List<Blog>
      {
        new Blog { Name = "BBB" },
        new Blog { Name = "ZZZ" },
        new Blog { Name = "AAA" },
      }.AsQueryable();
      var mockSet = Substitute.For<IDbSet<Blog>>();
      mockSet.Provider.Returns(data.Provider);
      mockSet.Expression.Returns(data.Expression);
      mockSet.ElementType.Returns(data.ElementType);
      mockSet.GetEnumerator().Returns(data.GetEnumerator());
      var mockContext = Substitute.For<BloggingContext>();
      mockContext.Blogs.Returns(mockSet);
      // Act and Assert ...
    }
