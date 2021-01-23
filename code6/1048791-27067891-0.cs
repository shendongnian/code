    public class Bar{}
    public class FooGeneric<T> : Bar
    {
        public static string SharedData {
            get {
                return Foo.SharedData;
            }
            set{
                Foo.SharedData = value;
            }
        }
    }
    
    internal class Foo
    {
        public static string SharedData = "Fizz";
    }
