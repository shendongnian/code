    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var with = new WithTypeConverter() { Bla = 12, Blub = "With" };
                var without = new WithoutTypeConverter() { Bla = 12, Blub = "Without" };
    
                Console.WriteLine(with);
                Console.WriteLine(JsonConvert.SerializeObject(with));
    
                Console.WriteLine(without);
                Console.WriteLine(JsonConvert.SerializeObject(without));
                Console.ReadKey();
            }
        }
    
        public class baseClass
        {
            public int Bla { get; set; }
            public string Blub { get; set; }
    
            public override string ToString()
            {
                return String.Format("{0}: {1}", this.GetType().Name, Blub);
            }
        }
    
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class WithTypeConverter : baseClass
        {
        }
    
        public class WithoutTypeConverter : baseClass
        {
        }
    }
