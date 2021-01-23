    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mco = new MyComplexObject();
                mco.MyDate1 = DateTime.Now;
                mco.MyDate2 = DateTime.Now;
                mco.MyDate3 = DateTime.Now;
                mco.MyString1 = "String1";
                mco.MyString2 = "String1";
                mco.MyString3 = "String1";
                
    
                var props = typeof(MyComplexObject).GetProperties();
                foreach (PropertyInfo propertyInfo in props)
                {
                    Console.WriteLine(string.Format("Name: {0}  PropertyValue: {1}", propertyInfo.Name, propertyInfo.GetValue(mco, null)));
                }
                Console.ReadLine();
            }
        }
    
    
        public class MyComplexObject
        {
            public string MyString1 { get; set; }
            public string MyString2 { get; set; }
            public string MyString3 { get; set; }
            public DateTime MyDate1 { get; set; }
            public DateTime MyDate2 { get; set; }
            public DateTime MyDate3 { get; set; }
        }
    
    }
