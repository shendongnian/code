    [TestMethod, DataSource(... SourceData1.csv ...)]
    public void MyFirstCodedUiTestMethod() {
        BodyOfTheTest();
    }
    [TestMethod, DataSource(... SourceData2.csv ...)]
    public void MySecondCodedUiTestMethod() {
        BodyOfTheTest();
    }
    public void BodyOfTheTest() {
        ...body of the test
        ... = TestContext.DataRow["UserName"].ToString();
        ... = TestContext.DataRow["Password"].ToString();
    }
