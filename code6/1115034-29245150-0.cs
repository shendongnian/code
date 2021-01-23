    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace StackOverflowTest
    {
        class Program
        {
            public static IEnumerable<XElement> GetRowsWithColumn(IEnumerable<XElement> rows, String name, String value) 
            {
                return rows
                    .Where(row => row.Elements("col")
                        .Any(col =>
                            col.Attributes("name").Any(attr => attr.Value.Equals(name))
                            && col.Value.Equals(value)));
            }
            static void Main(string[] args)
            {
                //Load file
                XElement elem = XElement.Load("./test.xml");
    
                //Get Rows
                var rows = elem
                    .Elements("catalog")
                    .Elements("row");
    
                //Filter rows
                var interestingRows = GetRowsWithColumn(rows, "NAZWA", "Miłogoszcz");
    
                //Print rows
                foreach (var row in interestingRows)
                {
                    //This is MessageBox.Show in your example
                    Console.WriteLine(row);
                }
    
                Console.Read();
            }
        }
    }
