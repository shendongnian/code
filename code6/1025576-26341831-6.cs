    [TestMethod]
    public void GetRows_ReturnsListOfThings()
    {
        // Arrange
        Mock<IExcelQueryFactory> mockExcelFile = new Mock<IExcelQueryFactory>();
        var thingsSheet = new ThingsSheet(mockExcelFile.Object, "file", "worksheet");
    
        mockExcelFile
            .Setup(x => x.Worksheet<Thing>(It.IsAny<string>()))
            .Returns(ExcelQueryableOfThing());
    
        // Act
        List<Thing> rows = thingsSheet.GetRows();
    
        // Assert
        Assert.AreEqual(2, rows.Count); // Adam and Eva
    }
