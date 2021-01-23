    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using FastMember;
    namespace ConsoleScratchPad
    {
        class Program
        {
            static void Main(string[] args)
            {
                IList<MyClass> ls = new List<MyClass>();
                ls.Add(new MyClass { MyColumn1 = "The" });
                ls.Add(new MyClass { MyColumn1 = "Big" });
                ls.Add(new MyClass { MyColumn1 = "Ant" });
                DataTable dt = new DataTable();
                using (var reader = ObjectReader.Create(ls))
                {
                    dt.Load(reader);
                }
            }
        }
        
        public class MyClass
        {
            public string MyColumn1 { get; set; }
        }
    }
