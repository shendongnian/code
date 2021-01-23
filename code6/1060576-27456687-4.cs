    public static void Main()
    {        
        var addresses = new List<Address>();
        var deserializer = new XmlSerializer(typeof(AddressDirectory));
        using (var reader = new StreamReader(@"C:\Users\Rufus\Documents\temp\temp.xml"))
        {
            addresses.AddRange(
                ((AddressDirectory)deserializer.Deserialize(reader)).addressList);
        }
        int counter = 1;
        foreach (var address in addresses)
        {
            Console.WriteLine("Information for item #{0}", counter++);
            Console.WriteLine(" - House Number ... {0}", address.HouseNo);
            Console.WriteLine(" - Street Name .... {0}", address.StreetName);
            Console.WriteLine(" - City ........... {0}\n", address.City);
        }
    }
