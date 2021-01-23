    namespace MyApp
    {
        public class MyClass
        {
            public static string MyString { get; set; }
            public MyClass()
            {
            }
        }
        public class MyOtherClass
        {
            public MyOtherClass()
            {
                MyClass.MyString = "Test";
            }
        }
    }
