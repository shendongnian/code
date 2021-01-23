    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Int32 i = 123;
                Double d = 0.0;
                Type t = d.GetType();
    
                // Print the type of d
                Console.WriteLine(t.Name); // "Double"
    
                var newI = DoStuff(t, i);
    
                // Print the new type of i
                Console.WriteLine(newI.GetType().Name); // "Double"
                Console.Read();
            }
    
            public static object DoStuff(object type, object inData)
            {
                Type newType = (Type)type;
    
                // Fix nullables...
                Type newNullableType = Nullable.GetUnderlyingType(newType) ?? newType;
    
                // ...and change the type
                return Convert.ChangeType(inData, newNullableType);
            }
        }
    }
