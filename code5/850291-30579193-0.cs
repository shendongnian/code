    [JsonConverter(typeof(BaseConverter))]
    abstract class Base
    {
        public int ObjType { get; set; }
        public int Id { get; set; }
    }
    
    class DerivedType1 : Base
    {
        public string Foo { get; set; }
    }
    
    class DerivedType2 : Base
    {
        public string Bar { get; set; }
    }
