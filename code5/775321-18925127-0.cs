    public abstract class Foo
    {
        public abstract void Save();
        public void Something()
        {
            // Get the media type
        }
    }
    public class FooText : Foo
    {
        public string MyId { get; set; }
        public string MyFile { get; set; }
        public string MyTextFile { get; set; }
        public override void Save()
        {
            // Save File to Txt
        }
    }
    public class FooXml : Foo
    {
        public string MyId { get; set; }
        public string MyFile { get; set; }
        public string MyXMLFile { get; set; }
        public override void Save()
        {
            // Save to XML
        }
    }
    public class FooFactory<T> where T : Foo, new()
    {
        public static T CreateFoo()
        {
            return new T();
        }
    }
