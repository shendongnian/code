    for (int i = 0; i < XmlData.addressList.Count; i++)
    {
        Console.WriteLine("Information for item #{0}", i + 1);
        Console.WriteLine(" - House Number ... {0}", XmlData.addressList[i].HouseNo);
        Console.WriteLine(" - Street Name .... {0}", XmlData.addressList[i].StreetName);
        Console.WriteLine(" - City ........... {0}", XmlData.addressList[i].City);
    }
