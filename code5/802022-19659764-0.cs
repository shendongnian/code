    public class Foo
    {
        Bar Field{get;set;}
        public int Value{get { return Field.Value;} }
        public int Value2{get { return Field.Value2;} }
    }
    public class Bar
    {
        public int Value{get;set};
        public int Value2{get;set;}
    }
