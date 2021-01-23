	var data = new List<DummyEntity> {
		new DummyEntity { Value1 = "First", Value2 = "001" } },
		new DummyEntity { Value1 = "Second", Value2 = "002" } }
	};
	var mockDummyEntities = MockHelper.CreateDbSet<DerivedDbSet<DummyEntities>, DummyEntities>(data, i => data.FirstOrDefault(k => k.Value2 == (string)i[0]));
	var mockContext = new Mock<DummyDbContext>();
	mockContext.Setup(c => c.DummyEntities).Returns(mockDummyEntities.Object);
