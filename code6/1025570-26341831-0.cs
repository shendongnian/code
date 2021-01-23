    // With delegate
    mockExcelQueryFactory
    .Setup(x => x.Worksheet<Thing>(It.IsAny<string>()))
    .Returns(() => 
        { 
            return new ExcelQueryable<Thing>
            {
            };
        }
    );
    // With expression
    mockExcelQueryFactory
    .Setup(x => x.Worksheet<Thing>(It.IsAny<string>()))
    .Returns(() => new ExcelQueryable<Thing> { });  
    // With method
    mockExcelQueryFactory
    .Setup(x => x.Worksheet<Thing>(It.IsAny<string>()))
    .Returns(ExcelQueryableOfThing()); 
    private ExcelQueryable<Thing> ExcelQueryableOfThing()
    {
        return new ExcelQueryable<Thing>();
    }
