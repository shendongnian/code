    public static void Main()
    {
        string filePath = "https://raw.githubusercontent.com/FortAwesome/Font-Awesome/master/src/icons.yml";
        WebClient client = new WebClient();
        string reply = client.DownloadString(filePath);
        var input = new StringReader(reply);
        //var yamlStream = new YamlStream();
        //yamlStream.Load(input);
        Deserializer deserializer = new Deserializer();
        //var icons = deserializer.Deserialize<IconSearch>(input);
    
        //Testing my own implementation
        //if (icons == null)
        //    Console.WriteLine("Icons is null");
    
        //Testing Shekhar's suggestion
        var root = deserializer.Deserialize<Rootobject>(input);
        if (root == null)
            Console.WriteLine("Root is null");
    }
