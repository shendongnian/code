    [Test, TestCaseSource("DivideCases")]
    public void DivideTest(string appNum, string hddSerial, string hddSerial)
    {
        string regNumber = Registration.GenerateKey(appNum, numDevices, hddSerial);
        Assert.IsTrue(Registration.CheckKey(regNumber, appNum, out numReadDevices, hddSerial),              "Generated key does not pass check.");
        Assert.AreEqual(int.Parse(numDevices), numReadDevices,"Number of registered devices does not match requested number");
    }
    
    static object[] DivideCases =
    {
        new object[] { "123", "3", "4" },
        new object[] { "12223", "35", "54" },
        new object[] { "12123123", "23", "14" }
    };
