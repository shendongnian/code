    //RootObject class definition generated using json2csharp.com
    //the rest of class definition removed for brevity.
    public class RootObject
    {
    	public int Count { get; set; }
    	public List<Item> Items { get; set; }
    }
    ........
    ........
    //in main method
    var jsonString = .....;
    //deserialize json to strongly-typed object
    RootObject result = JsonConvert.DeserializeObject<RootObject>(jsonString);
    foreach(var item in result.Items)
    {
    	//then you can access Json property like common object property
    	Console.WriteLine(item.UserId.S);
    }
