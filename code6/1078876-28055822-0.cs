    private static void Main(string[] args)
    {
        using (var xmlReader = XmlReader.Create("http://rss.theweathernetwork.com/weather/caab0211"))
        {
            xmlReader.ReadToFollowing("description");
            Console.WriteLine(xmlReader.ReadElementString());
        }
    }
