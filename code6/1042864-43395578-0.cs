    [TestClass]
    public class RegistrationTests
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource(
            "System.Data.OleDb", 
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\MySolution\Serial numbers.mdb""",
            "Serials",
            DataAccessMethod.Sequential
        )]
        public void GeneratingValidKeyTest()
        {
            // Arrange
            int numReadDevices;
            var appNum = TestContext.DataRow["appNum"].ToString();
            var hddSerial = TestContext.DataRow["hddSerial"].ToString();
            var numDevices = TestContext.DataRow["numDevices"].ToString();
            // Act
            var regNumber = Registration.GenerateKey(appNum, numDevices, hddSerial);
            // Assert
            Assert.IsTrue(
                Registration.CheckKey(regNumber, appNum, out numReadDevices, hddSerial), 
                "Generated key does not pass check."
            );
            Assert.AreEqual(
                int.Parse(numDevices), numReadDevices, 
                "Number of registered devices does not match requested number"
            );
        }
    }
