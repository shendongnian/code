    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    
    namespace DynamicColumns
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                Console.WriteLine ("Total all quantity columns");
                
                var dt = new DataTable ();
                dt.Columns.Add ("ProductName", typeof(string));
                dt.Columns.Add ("Qty1", typeof(int));
                dt.Columns.Add ("Qty2", typeof(int));
                dt.Columns.Add ("Qty3", typeof(int));
                
                {
                    var dr = dt.NewRow ();
                    dr ["ProductName"] = "Keyboard";
                    dr ["Qty1"] = 2;
                    dr ["Qty2"] = 5;
                    dr ["Qty3"] = 6;
                    dt.Rows.Add (dr);
                }
                
                {
                    var dr = dt.NewRow ();
                    dr ["ProductName"] = "Mouse";
                    dr ["Qty1"] = 5;
                    dr ["Qty2"] = 1;
                    dr ["Qty3"] = 2;
                    dt.Rows.Add (dr);
                }
    
    
    
                
                string expression = 
    
                    string.Join (" + ", 
                        dt.Columns.OfType<DataColumn>()
                            .Where(x => x.DataType == typeof(int))
                            .Select(x => x.ColumnName)
                             .ToArray() );
    
                dt.Columns.Add("Total", typeof(int)).Expression = expression;
    
    
                Console.WriteLine ("Expression: {0}",expression);
    
                Console.WriteLine ("\nProduct and totals");
                foreach (var r in dt.Rows.OfType<DataRow>()) {
                    Console.WriteLine ("{0} {1}", r["ProductName"], r["Total"]);
                }
                
                
            }
        }
    }
