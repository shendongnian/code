    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
    
        public static void Main()
        {
            var listValue = new List<string>()
            {
                "Hello",
                "Hello2",
                "Hello3",
            };
        
            var sampleClass = new SampleClass();
            var sampleType = sampleClass.GetType();
            var properties = sampleType.GetProperties().OrderBy(prop => prop.Name).ToList();
            for (int i = 0; i < listValue.Count; i++)
            {
                if (i < properties.Count)
                {
                    properties[i].SetValue(sampleClass, listValue[i]);
                    Console.WriteLine(properties[i].Name + " = " + listValue[i]);
                }
            }
            Console.ReadLine();
        }
        
        public class SampleClass
        {
            public string _VarA { get; set; }
            public string _VarB { get; set; }
            public string _VarC { get; set; }
            //around 40 attribute
        }
    }
