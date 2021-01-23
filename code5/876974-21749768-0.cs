    namespace UnitTest
    {
        using System;
    
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine(ConvertToType(DateTime.Now).GetType().Name);
                Console.WriteLine(ConvertToType<Guid>(Guid.NewGuid()).GetType().Name);
                Console.Read();
            }
    
            public static dynamic ConvertToType(object obj)
            {
                //If you're unsure of the type you want to return.
                return Convert.ChangeType(obj, obj.GetType());
            }
    
            public static T ConvertToType<T>(object obj)
            {
                //If you definitely know the type you want to return.
                return (T)Convert.ChangeType(obj, typeof(T));
            }
        }
    }
