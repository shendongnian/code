    public class ItemWithProperty
    {
        public string Property { get; set; }
    }
    
    public static void Main()
    {
        Dictionary<string, Func<ItemWithProperty, IComparable>> stringPropertyMap = new Dictionary<string, Func<ItemWithProperty, IComparable>>()
        {
           {"param1", item => item.Property}
        };
        List<ItemWithProperty> toBeOrdered = new List<ItemWithProperty>();
        string[] parameters = {"param1"};
        var sorted = toBeOrdered.OrderBy(stringPropertyMap[parameters[0]]);
    }
