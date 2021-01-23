    var data = new MeterWalkOrder{ Name = "Red Route", Meters = new List<IMeter>
    {
    	 new Meter{ MeterID = 1, SerialNumber = "12345"},
    	 new Meter{ MeterID = 2, SerialNumber = "SE"}
    }};
    using (var stream = new FileStream("C:\\Users\\Adam\\Desktop\\Test2.xml", FileMode.OpenOrCreate))
    {
    	XmlSerializer ser = new XmlSerializer(typeof(MeterWalkOrder));
    	ser.Serialize(stream, data);
    }
