    var configManager = new StubIConfigManager();
    configManager.GetSettingOf1(() => "TestString");
    configManager.GetSettingOf1(() => 23);
    var stringResult = configManager.GetSetting<string>();
    var intResult = configManager.GetSetting<int>();
    Assert.AreEqual("TestString", stringResult);
    Assert.AreEqual(23, intResult);
