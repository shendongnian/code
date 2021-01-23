    private static void Main(string[] args)
    {
    	var station = new Station {Name = "Duren Kalibata", LastTemperature = 45, MostRecentDate = DateTime.Now};
    	var str = JsonConvert.SerializeObject(station);
    	Console.WriteLine(str);
    }
