    public class MyClass
    {
        public Int32 a;
        public string b; //struct
    }
    
    string json = "{ a: 7, b:'abc' }";
    MyClass cc = JsonConvert.DeserializeObject<MyClass>(json);
