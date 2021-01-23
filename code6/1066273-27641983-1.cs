    public class Item
    {
        public string MyProperty { get; set; }
        public string MyProperty3 { get; set; }
        public string MyProperty2 { protected get; set; }
        public Item()
        {
            MyProperty = "Test propery";
            MyProperty3 = "Test property 3";
            MyProperty2 = "Yoohoo";
        }
    }
