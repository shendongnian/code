    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ConsoleApplication1
    {
    
    
        public class Criterion
        {
            public static void Main()
            {
                // your code goes here
                var c = new Criterion("IsActive", OperationCode.EQUALS, false);
                c = new Criterion("AgeRange", OperationCode.BETWEEN, 18, 35);
                Console.ReadKey();
    
            }
    
    
            public Criterion(string fieldName, OperationCode op, params object[] value)
            {
                string FieldName = fieldName;
                OperationCode Op = op;
                object[] values = value;
                object val = values[0];
                string display = String.Format("{0} {1} {2}", FieldName, Op, values[0]);
                Console.WriteLine(display);
                Console.WriteLine(values[0].GetType().Name);
                Console.WriteLine(values.GetType().Name);
                Console.WriteLine(val.GetType().Name, val);
            }
    
        }
    
        public enum OperationCode
        {
            EQUALS,
            BETWEEN
        };
    
    }
