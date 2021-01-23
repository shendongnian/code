    [TestMethod]
    public void DeleteRequirementSuccessfully()
    {
        var requirements = new List<Requirement>
        {
            new Requirement {
                Id = 1,
                Title = "Requirement 1",
                Description = "Requirement 1 description"
            },
            new Requirement {
                Id = 2,
                Title = "Requirement 2",
                Description = "Requirement 2 description"
            },
            new Requirement {
                Id = 3,
                Title = "Requirement 3",
                Description = "Requirement 3 description"
            }
        };
        var mockDbSet = new Mock<DbSet<Requirement>>();
        var context = new Mock<RequirementsDatabaseEntities>();
        // You should use .AsQueryable() in these lines
        mockDbSet.As<IQueryable<Requirement>>()
                 .Setup(x => x.Provider)
                 .Returns(requirements.AsQueryable().Provider);
        mockDbSet.As<IQueryable<Requirement>>()
                 .Setup(x => x.ElementType)
                 .Returns(requirements.AsQueryable().ElementType);
        mockDbSet.As<IQueryable<Requirement>>()
                 .Setup(x => x.Expression)
                 .Returns(requirements.AsQueryable().Expression);
        mockDbSet.As<IQueryable<Requirement>>()
                 .Setup(x => x.GetEnumerator())
                 .Returns(requirements.GetEnumerator());
        // This line should be added
        mockDbSet.Setup(m => m.Remove(It.IsAny<Requirement>())).Callback<Requirement>((entity) => requirements.Remove(entity));
        context.Setup(x => x.Requirement).Returns(mockDbSet.Object);
        var dataAccess = new RequirementsDataAccess(context.Object);
        int idToDelete = 1;
        dataAccess.DeleteRequirement(idToDelete);
        context.VerifyGet(x => x.Requirement, Times.Exactly(2));
        //mockDbSet.Verify(x => x.Remove(It.IsAny<Requirement>()), Times.Once());
        context.Verify(x => x.SaveChanges(), Times.Once());
        // add this Assert
        Assert.AreEqual(requirement.Count, 2);
        // or
        Assert.IsFalse(requirement.Any(x => x.Id == idToDelete));
    }
