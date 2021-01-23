    using System;
     
    public class HelloWorld {
        static public void Main() {
            var result = test.factory(DataTypes.Float32);
            Type type = result.GetType();
            Console.WriteLine(type.FullName);
            result = test.factory(DataTypes.Integer32);
            type = result.GetType();
            Console.WriteLine(type.FullName);
        }
    }
