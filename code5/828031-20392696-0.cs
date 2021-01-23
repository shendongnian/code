    [Test]
    public void RemoveDuplicates()
    {
        // Arrange
        var mainList = new List<string>() { "Bogus", "Boobs", "Brains" };
        var subList = new List<string>() { "Bogus" };
        // Act
        mainList = mainList.Except(subList).ToList();
        // Assert
        Assert.IsFalse(mainList.Any(search => subList.Contains(search)));
     }
