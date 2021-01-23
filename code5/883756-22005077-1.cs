    Settings s = new Settings();
    MemoryStream stream1 = new MemoryStream();
    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Settings));
    // Write the settings
    ser.WriteObject(stream1, s);
    // Read settings
    Person p2 = (Person)ser.ReadObject(stream1);
