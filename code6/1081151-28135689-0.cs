    public class MyClass
    {
        Int32 a;
        string b; //struct
    }
    string json = "{ a: 7, b:'abc' }";
    MyClass cc = JsonConvert.DeserializeObject<MyClass>(json);
