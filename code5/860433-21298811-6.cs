    class Program
    {
        static void Main(string[] args)
        {
            // The first 12 values should deserialize to correct values;
            // the last 7 should all be forced to MyEnum.Zero.
            string json = @"
            {
                ""MyEnumList"":
                [
                    ""Zero"", 
                    ""One"", 
                    ""Two"", 
                    0,
                    1,
                    2,
                    ""zero"",
                    ""one"",
                    ""two"",
                    ""0"",
                    ""1"",
                    ""2"",
                    ""BAD"", 
                    ""123"", 
                    123, 
                    1.0,
                    null,
                    false,
                    true
                ]
            }";
            MyClass obj = JsonConvert.DeserializeObject<MyClass>(json, 
                                                       new StrictEnumConverter());
            foreach (MyEnum e in obj.MyEnumList)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public enum MyEnum
        {
            Zero = 0,
            One = 1,
            Two = 2
        }
        public class MyClass
        {
            public List<MyEnum> MyEnumList { get; set; }
        }
    }
