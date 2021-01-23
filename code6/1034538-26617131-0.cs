    foreach (Vehicle v in vehicles)
    {
        if (elementCount < 1000)
        {
            writer.WriteLine(CreateVehicleXmlElement.BuildElement(v));
            elementCount++;
        }
        else if (elementCount == 1000)
        {
             writer.Close();
             fileNumber++;
             elementCount = 0;
             baseName = "c:\\test\\" + DateTime.Now.ToString("ddMMyyy") + "_0" + fileNumber + ".";
             writer = new StreamWriter(baseName + "xml");
             writer.WriteLine("This is the header that will be filled in later");
             writer.WriteLine(CreateVehicleXmlElement.BuildElement(v));
             elementCount++;
        }
    }
    writer.Close();
