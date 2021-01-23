    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [ModelBinder]
    public class HeaderModel
    {
        public int Version { get; set; }
        public string Test { get; set; }
    }
