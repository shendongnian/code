    DbSet<Models.Systems> data = new DbSet<Models.System> {
        new Models.System { Id = 1, Name = "test 1" },
        new Models.System { Id = 2, Name = "test 2" }
      };
    mockContext.Setup(c => c.Systems).Returns(data);
