    [DataSource...
        TestMethod]
    public void CodedUITestMethod1()
    {
        this.UIMap.EnterValueParams.UIItem0TextSendKeys = TestContext.DataRow["ValueOne"].ToString();
        this.UIMap.EnterValueParams.UIItem1TextSendKeys = TestContext.DataRow["ValueTwo"].ToString();
        this.UIMap.EnterValue();
        this.UIMap.CheckResultExpectedValues.UIItem0TextDisplayText = TestContext.DataRow["Result"].ToString();
        this.UIMap.CheckResult();
    }
