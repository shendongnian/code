    using System;
    using System.Reflection;
    
    public class Example
    {
        public int PublicProp { get { return 10; } }
    
        private int PrivateProp { get { return 5; } }
    }
    
    public class Program
    {
        public static void Main()
        {
            Example myExample = new Example();
    
            Console.WriteLine("PublicProp: " + myExample.PublicProp);
    
            PropertyInfo[] properties = typeof(Example).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
    
            foreach (PropertyInfo prop in properties)
            {
                Console.WriteLine(prop.Name + ": " + prop.GetValue(myExample));
            }
    
            Console.ReadKey();
        }
    }
