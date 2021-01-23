        private Vehicle _vehicle = new Vehicle
        {
            Doors = 4,
            Wheels = "22 inch",
            Windows = "Tinted",
            Engine = Engine.V6,
            ManufactureTimestamp = Convert.ToDateTime("2014-11-24T06:04:02.000000")
        };
        [TestMethod]
        public void SerializeObjectToXmlString()
        {
            string xml = XmlSerializationHelper.Serialize<Vehicle>(_vehicle);
            Assert.IsTrue(xml.Contains("<Wheels>22 inch</Wheels>"));
            Assert.IsTrue(xml.Contains("<ManufactureTimestamp>2014-11-24T06:04:02.000000</ManufactureTimestamp>"));
        }
