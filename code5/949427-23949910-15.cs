    [TestMethod]
    public void Should_be_able_to_extract_a_single_parameter()
    {
        var line = "G195=Out:LED0799";
        var sut = new SettingsParser();
        var actual = sut.ExtractLine(line);
        Assert.AreEqual("LED0799", actual.Parameters["Out"]);
    }
    [TestMethod]
    public void should_be_able_to_parse_multiple_properties()
    {
        var line = "G195=Out:LED0799 Invert:00";
        var sut = new SettingsParser();
        var actual = sut.ExtractLine(line);
        Assert.AreEqual("00", actual.Parameters["Invert"]);
    }
