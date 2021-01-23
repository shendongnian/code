    // you can generate your class with http://json2csharp.com/
    public class Product
    {
        public string ProductCode { get; set; }
        public int Discount { get; set; }
    }
	
	public void Main()
    {
		string json = "[{\"productCode\": \"1111111\", \"discount\": \"5\"}, {\"productCode\": \"2222222\", \"discount\": \"5\"}]";
		
		var m = JsonConvert.DeserializeObject<List<Product>>(json);
		Console.WriteLine(m[0].Discount);
    }
