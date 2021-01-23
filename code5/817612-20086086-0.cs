    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                StringBuilder string1 = new StringBuilder();
                StringBuilder string2 = new StringBuilder();
                StringObjectMapper mapper = new StringObjectMapper();
                mapper.Add("STRING1", ref string1);
                mapper.Add("STRING2", ref string2);
                mapper.Set("STRING1", "text1");
                Console.Write("text1" == string1.ToString());
                Console.ReadKey();
            }
        }
        public class StringObjectMapper
        {
            private Dictionary<string, StringBuilder> mapping = new Dictionary<string, StringBuilder>();
            public StringObjectMapper()
            {
            }
            public void Set(string key, string value)
            {
                StringBuilder obj = mapping[key];
                obj.Clear();
                obj.Append(value);
            }
            internal void Add(string p, ref StringBuilder string1)
            {
                mapping.Add(p, string1);
            }
        }
    }
