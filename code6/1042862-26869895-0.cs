    [Test]
    public void DivideTest([ValueSource("AppNums")]string appNum, [ValueSource("Serials")]string hddSerial, [ValueSource("NumDevices")]string numDevices)
    {
        string regNumber = Registration.GenerateKey(appNum, numDevices, hddSerial);
        Assert.IsTrue(Registration.CheckKey(regNumber, appNum, out numReadDevices, hddSerial), "Generated key does not pass check.");
        Assert.AreEqual(int.Parse(numDevices), numReadDevices,"Number of registered devices does not match requested number");
    }
    static object[] AppNums =
    {
        "1", "2", "3", "4", "5", "6", "7"
    };
    static object[] Serials =
    {
        "EXAMPLE", "ANOTHER", "AND AGAIN"
    };
    static object[] NumDevices =
    {
        "1", "2", "3", "4", "5", "6", "7"
    };
