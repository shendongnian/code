    string hexValue = "529CD17C";
    int secondsAfterEpoch = Int32.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    DateTime epoch = new DateTime(1970, 1, 1);
    DateTime myDateTime = epoch.AddSeconds(secondsAfterEpoch);
    Console.WriteLine(myDateTime);
    
