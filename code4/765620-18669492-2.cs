    public class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint[] endpoints = new IPEndPoint[]
            {
                new IPEndPoint(IPAddress.Parse("8.8.4.4"), 53),
                new IPEndPoint(IPAddress.Parse("2001:db8::ff00:42:8329"), 81)
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new IPAddressConverter());
            settings.Converters.Add(new IPEndPointConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(endpoints, settings);
            Console.WriteLine(json);
            IPEndPoint[] endpoints2 = 
                JsonConvert.DeserializeObject<IPEndPoint[]>(json, settings);
            foreach (IPEndPoint ep in endpoints2)
            {
                Console.WriteLine();
                Console.WriteLine("AddressFamily: " + ep.AddressFamily);
                Console.WriteLine("Address: " + ep.Address);
                Console.WriteLine("Port: " + ep.Port);
            }
        }
    }
