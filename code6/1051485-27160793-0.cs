    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace stackOverflowRandomRefTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var random = new Random();
    			for (int i = 0; i < 10; i++)
    			{
    				var originCity = CityInfo.GetCity(random, null);
    				var destinationCity = CityInfo.GetCity(random, originCity);
    				Console.WriteLine(String.Format("orig: {0} {1}",originCity.CityName, originCity.Zip));
    				Console.WriteLine(String.Format("dest: {0} {1}",destinationCity.CityName, destinationCity.Zip));
    			}
    			Console.ReadKey();
    		}
    	}
    	public class CityInfo
    	{
    		public string CityName { get; set; }
    		public string State { get; set; }
    		public string Zip { get; set; }
    		public IEnumerable<string> ZipCodes { get; set; }
    
    		private static readonly IEnumerable<CityInfo> Cities = new[]{
            new CityInfo{
                CityName = "New York",
                State = "NY",
                ZipCodes = new[]{"10001", "10002", "10003", "10004", "10005"}
            },
            new CityInfo
            {
                CityName = "Washington",
                State="DC",
                ZipCodes = new []{"20001", "20002", "20003", "20004","20005"}
            }
    		};
    
    		private static T GetRandom<T>(IEnumerable<T> list, Random generator)
    		{
    			int n = generator.Next(list.Count());
    			Console.WriteLine(n);
    			return list.ToArray()[n];
    		}
    
    		public static CityInfo GetCity(Random random, CityInfo notThisCity)
    		{
    			var city = GetRandom(Cities, random);
    			while (city == notThisCity)
    			{  // if there is only one city this is infinite...
    				city = GetRandom(Cities, random);
    			}
    			city.Zip = GetRandom(city.ZipCodes, random);
    			return city;
    		}
    
    	}
    }
