    [Test]
    public void RemoveDuplicates()
    {
        // Arrange
        var mainList = new List<string>() { "Bogus", "Bodacious", "Brains" };
        var subList = new List<string>() { "Bogus" };
        // Act
        mainList.RemoveAll(search => subList.Contains(search)); // or if not a list 
        mainList = mainList.Except(subList).ToList(); 
        // Assert
        Assert.IsFalse(mainList.Any(search => subList.Contains(search)));
     }
