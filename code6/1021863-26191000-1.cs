    public class SomeMasterClass
    {
        public static ISomeInterface CreateObject()
        {
            if (DateTime.Now.Year % 3 == 0) {
                return new Example1();
            } else {
                return new Example2();
            }
        }
    }
