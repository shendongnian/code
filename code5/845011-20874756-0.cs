    public class Entity : List<Property>
    {
        public Entity()
        {
        }
    }
    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DisplayType DisplayType { get; set; }
    }
    public enum DisplayType
    {
        TextBox,
        Checkbox
    }
