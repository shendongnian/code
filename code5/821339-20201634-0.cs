    void Main()
    {
        var item = JsonConvert.DeserializeObject<InventoryItem>(@"{""Id"": 1}",
             new JsonSerializerSettings {
                    DefaultValueHandling = DefaultValueHandling.Populate });
        // item.PackSize == 1
    }
    public class InventoryItem
    {
        public string Id { get; set; }
        [DefaultValue(1)]
        public Int16 PackSize { get; set; }
        [DefaultValue("")]
        public string Description { get; set; }
        public Double DeptDotSubdept { get; set; }
    }
