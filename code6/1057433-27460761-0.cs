	using System;
	using System.Linq;
	using Newtonsoft.Json.Linq;
	namespace ConsoleApplication1
	{
		static class Program
		{
			static void Main()
			{
				try
				{
					const string output = @"{""champions"": [  {
		""id"": 40,
		""stats"": 
		{
			""totalSessionsPlayed"": 10,
			""totalSessionsLost"": 8,
			""totalSessionsWon"": 2,
		}  
	},
	{    
		""id"": 6,
		""stats"":
		{      
			""totalSessionsPlayed"": 3,
			""totalSessionsLost"": 2,
			""totalSessionsWon"": 1, 
		}  
	}
	]}";
					var objectRankedStats = JObject.Parse(output)["champions"];
					var champ = objectRankedStats.FirstOrDefault(jt => (int)jt["id"] == 6);
					Console.WriteLine(champ);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}
	}
