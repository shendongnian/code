	class Program
	{
		static void Main(string[] args)
		{
			var cityList = new List<City>();
			cityList.Add(new City
			{
				cityName = "Stockholm",
				cityTemp = 22.65f
			});
			cityList.Add(new City
			{
				cityName = "London",
				cityTemp = 25.24f
			});			
			Console.WriteLine("List: ");
			foreach (var city in cityList)
			{
				Console.WriteLine(city);
			}
			Console.ReadKey();
		}
	}
