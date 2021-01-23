    [Theory]
    [AutoMoqPropertyData("Case1")]
    [AutoMoqPropertyData("Case2")]
    [AutoMoqPropertyData("Case3")]
    [AutoMoqPropertyData("Case4")]
    public void ShouldMapEnum(
        MsgData msgData, CustomEnum expectedEnum, SomeObject sut)
    {
        var customEnum = sut.GetEnum(msgData);
        Assert.Equal(expectedEnum, customEnum);
    }
    public static IEnumerable<object[]> Case1 { get {
        yield return new object[] { 
            new MsgData { Code = "1" }, CustomEnum.Value1 }; } }
    public static IEnumerable<object[]> Case2 { get {
        yield return new object[] { 
            new MsgData { Code = "2" }, CustomEnum.Value2 }; } }
    public static IEnumerable<object[]> Case3 { get {
        yield return new object[] { 
            new MsgData { Code = "3" }, CustomEnum.Value3 }; } }
    public static IEnumerable<object[]> Case4 { get {
        yield return new object[] { 
            new MsgData { Code = "4" }, CustomEnum.Value4 }; } }
