    public class MyClass
    {
        public Int32 a;
        public test b;
        public eMyEnum c;
    }
    public struct test
    {
        public string str;
    }
    public enum eMyEnum
    {
        A = 0,
        B
    }
    
    string json = "{ a: 7, b: {str:'str'}, c: 'B' }";
    MyClass cc = JsonConvert.DeserializeObject<MyClass>(json);
