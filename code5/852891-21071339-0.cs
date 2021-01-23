    public class Fruit
	{
		public string id;
		public string name;
	}
	public class FruitCollection
	{
		public List<Fruit> fruits;
	}
    ...
    string jsonString = "Your JSON string goes here";
	DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FruitCollection));
	FruitCollection fruitCollection = null;
	using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
	{
	    fruitCollection = (FruitCollection)ser.ReadObject(ms);
	}
