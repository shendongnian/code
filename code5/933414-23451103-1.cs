	void Main()
	{
		var my_object = new MyObject() {
			  SellPricePerKey = 70, // cena klucza w scrapach np. 31 / 9 = 3.55 ref
			  BuyPricePerKey = 69, // cena klucza w scrapach np e.g. 29 / 9 = 3.33 ref
			  SellPricePerTod = 33,// cena ToD'a w scrapach np. 31 / 9 = 3.55 ref
			  BuyPricePerTod = 28 // c
		};
		// create the JSON
		var json_my_object = Newtonsoft.Json.JsonConvert.SerializeObject(my_object);
		
		// Retrun an a JObject with 4 objects
		var normal_deserialized_object = Newtonsoft.Json.JsonConvert.DeserializeObject(json_my_object);
		
		// Or deserialize object and play with inner bits
		Newtonsoft.Json.Linq.JObject another_deserialized_object =
			(Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(json_my_object);
			
		foreach (var pair   in another_deserialized_object)
		{
			Console.WriteLine("Key:[{0}] , Value:[{1}]", pair.Key, pair.Value);
		}
		
	}
	// Define other methods and classes here
	public class MyObject {
		public	int SellPricePerKey ;
		public  int BuyPricePerKey;
		public	int SellPricePerTod ;
		public	int BuyPricePerTod;
	}
