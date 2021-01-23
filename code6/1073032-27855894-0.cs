    ﻿using Newtonsoft.Json.Linq;
    using System;
    
    namespace DynamicTest
    {
        public class Program
        {
            public void Main(string[] args)
            {
    
                dynamic dobject = JObject.Parse("{number:1000, str:'string', array: [1,2,3,4,5,6]}");
    
                Console.WriteLine(dobject.number);
                Console.WriteLine(dobject.str);
                Console.WriteLine(dobject.array.Count);
                Console.ReadLine();
            }
        }
    }
