    public class ItemWithProperty
    {
        public string Property { get; set; }
    }
    
    public static void Main()
    {
        Dictionary<string, Func<ItemWithProperty, object>> stringPropertyMap = new Dictionary<string, Func<ItemWithProperty, object>>()
        {
           {"param1", item => item.Property}
        };
        List<ItemWithProperty> toBeOrdered = new List<ItemWithProperty>();
        stringPropertyMap.Add("param1", (x)=> x.Property);
        string[] parameters = {"param1"};
        var sorted = toBeOrdered.OrderBy(stringPropertyMap[parameters[0]]);
    }
