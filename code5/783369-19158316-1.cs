	public void GetDataTest()
	{
		var mockRepository = new Mock<IBlogRepository>();
		mockRepository.Setup(r => r.GetAllBlogs()).Returns(new List<BlogDetail>());
		Default target = new Default(mockRepository.Object);
		
		var actual = target.GetData();
		Assert.AreEqual(0, actual.Count);		
		mockRepository.Verify(r => r.GetAllBlogs(), Times.Once());
	}
