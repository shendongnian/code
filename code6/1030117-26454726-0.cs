	public void Deserialize()
	{
		var json = @"{
			'response':{  
			'6112':{  
			'ID':6112,
			'Title':'Additional Photos',
			},
			'5982':{  
			'ID':5982,
			'Title':'Bike Ride',
			},
			'total_records': '20',
			'returned_count': 10,
			'returned_records': '1-10',
			}
		}";
		var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ss>(json);
		responseObj.Data = new Dictionary<string, Product>();
		foreach (var kv in responseObj.Response)
		{
			int id;
			if (int.TryParse(kv.Key, out id))
			{
				var product = kv.Value.ToObject<Product>();
				responseObj.Data[kv.Key] = product;
			}
			else if (kv.Key == "total_records")
			{
				responseObj.total_records = kv.Value.ToObject<int>();
			}
			else if (kv.Key == "returned_count")
			{
				responseObj.returned_count = kv.Value.ToObject<int>();
			}
			else if (kv.Key == "returned_records")
			{
				responseObj.returned_records = kv.Value.ToObject<string>();
			}
		}
	}
	public class Product
	{
		public string Id { get; set; }
		public string Title { get; set; }
	}
	public class ss
	{
		public Dictionary<string, Newtonsoft.Json.Linq.JToken> Response { get; set; }
		public int total_records { get; set; }
		public Dictionary<string, Product> Data { get; set; }
		public int returned_count { get; set; }
		public string returned_records { get; set; }
	}
