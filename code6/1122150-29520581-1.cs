    [ModelBinder(typeof(InjectedObjectModelBinder))]
    public class InjectedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ConstructedObject
    {
        public int A { get; set; }
        public int B { get; set; }
        public string C { get; set; }
    }
