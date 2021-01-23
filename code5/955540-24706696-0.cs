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
        var found = userQry.Where("Id in @0", successValues);
        var notFound = userQry.Where("Id in @0", failValues);
        //Assert
        Assert.AreEqual(userList[0].Id, found1.Single().Id);
        Assert.IsFalse(notFound1.Any());
    }
