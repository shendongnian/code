    namespace ConsoleApplication1
    {
        using System.Collections.Generic;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Container> table1 = new List<Container>()
                {
                    new Container { Column1 = "Sam", Column2 = "Fred" },
                    new Container { Column1 = "Arnold", Column2 = "Frank" }
                };
    
                List<Container> table2 = new List<Container>()
                {
                    new Container { Column1 = "Whitwicky", Column2 = "Flintstone" },
                    new Container { Column1 = "Schwartz", Column2 = "Sinatra" }
                };
    
                var result = Example.MergeTables(table1, table2);
            }
        }
    
        public class Example
        {
            public static IEnumerable<Container> MergeTables(List<Container> table1, List<Container> table2)
            {
                return table1.Select((value, index) =>
                    new Container
                    {
                        Column1 = value.Column1 + " " + table2[index].Column1,
                        Column2 = value.Column2 + " " + table2[index].Column2
                    });
    
            }
        }
    
        public class Container
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
        }
    }
