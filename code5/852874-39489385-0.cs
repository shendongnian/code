	public void GetAllBlogs_orders_by_name()
	{
	  // Arrange
	  var data = new List<Blog>
	  {
		 new Blog { Name = "BBB" },
		 new Blog { Name = "ZZZ" },
		 new Blog { Name = "AAA" },
	  };
	  var mockContext = Substitute.For<BloggingContext>();
	  
	  // Create and assign the substituted DbSet
	  var mockSet = data.GenerateMockDbSet();
	  mockContext.Blogs.Returns(mockSet);
	  
	  // act
	}
