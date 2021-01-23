    using System;
    using System.Linq;
    public class Class1
    {
        public string ABC { get; set; }
        public string DEF { get; set; }
        public string GHI { get; set; }
        public string JLK { get; set; }
    }
    class Program
    {
        static void Main()
        {
            // Do this if you know the type at compilation time
            var propertyNames 
                = typeof(Class1).GetProperties().Select(x => x.Name);
            // Do this if you have an instance of the type
            var instance = new Class1();
            var propertyNamesFromInstance 
                = instance.GetType().GetProperties().Select(x => x.Name);
        }
    }
