    public class CustomClass<T>
        where T : Base
    {
        public string stringTest { get; set; }
        public int numberTest { get; set; }
        public T foo { get; set; }
    }
