    [TestMethod]
    public void ExpressionTests_ContainsGuid()
    {
        //Arrange
        
        //Generate some users with Id fields of type Guid
        var userList = User.GenerateSampleModels(5, false); 
        var userQry = userList.AsQueryable();
        //Generate a list of values that will fail.
        var failValues = new List<Guid>() { 
            new Guid("{22222222-7651-4045-962A-3D44DEE71398}"), 
            new Guid("{33333333-8F80-4497-9125-C96DEE23037D}"), 
            new Guid("{44444444-E32D-4DE1-8F1C-A144C2B0424D}") 
        };
        //Add a valid Guid so that this list will succeed.
        var successValues = failValues.Concat(new[] { userList[0].Id }).ToArray();
        //Act
        var found1 = userQry.Where("Id in @0", successValues);
        var found2 = userQry.Where("@0.Contains(Id)", successValues);
        var notFound1 = userQry.Where("Id in @0", failValues);
        var notFound2 = userQry.Where("@0.Contains(Id)", failValues);
        //Assert
        Assert.AreEqual(userList[0].Id, found1.Single().Id);
        Assert.AreEqual(userList[0].Id, found2.Single().Id);
        Assert.IsFalse(notFound1.Any());
        Assert.IsFalse(notFound2.Any());
    }
