    public class MyClass
    {
        public string String1;
        public string String2;
        public MyClass()
        {
        }
        public static MyClass Instance(string json)
        {
            return new JsonConvert.DeserializeObject<MyClass>(json);
        }
    }
