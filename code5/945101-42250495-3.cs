    [TypeConverter(typeof(OrderModelUriConverter))] // my custom type converter, which is described below
    public class OrderParameter
    {
        public string OrderBy { get; set; }
        public int OrderDirection { get; set; }
    }
    public class ArticlesSearchModel
    {
        public OrderParameter Order { get; set; }
        // whatever else
    }
