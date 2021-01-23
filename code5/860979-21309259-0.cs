    using System;
    using System.Linq;
    
    namespace ConsoleApplication3
    {
        public class dtHeader
        {
            public dtHeader ParentHeader { get; set; }
            public string HeaderText { get; set; }
            public string DataField { get; set; }
            public bool Visible { get; set; }
            public int DisplayOrder { get; set; }
            public int Depth
            {
                get
                {
                    // If header has parent, then this depth is parent.depth + 1
                    if (ParentHeader != null)
                        return ParentHeader.Depth+1;
                    else
                        return 1; // No parent, root is depth 1
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                dtHeader[] headers = { 
                                         new dtHeader { HeaderText = "dt1" },
                                         new dtHeader { HeaderText = "dt2" },
                                         new dtHeader { HeaderText = "dt3" },
                                         new dtHeader { HeaderText = "dt4" },
                                         new dtHeader { HeaderText = "dt5" }
                                     };
    
                headers[1].ParentHeader = headers[0];
                headers[2].ParentHeader = headers[1];
                headers[3].ParentHeader = headers[2];
                headers[4].ParentHeader = headers[3];
    
                var deepest = headers.OrderByDescending(item=>item.Depth).First();
                Console.WriteLine(deepest.Depth+ ", " + deepest.HeaderText);
    
                var runner = deepest;
                while (runner.ParentHeader != null)
                    runner = runner.ParentHeader;
    
                Console.WriteLine("The deepest root header is:" + runner.HeaderText);
            }
        }
    }
