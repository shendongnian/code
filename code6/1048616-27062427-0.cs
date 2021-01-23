    [TestMethod]
    public async Task TestIfListFilled()
    {
        // arrange
        byte stuffTypeID = 0;
        // act
        List<Stuff> locationList = await GetStuffListAsync(stuffTypeID );
        // assert
        Assert.IsTrue(locationList.Count > 0);
    }
