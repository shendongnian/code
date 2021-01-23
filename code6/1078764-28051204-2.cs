    class Range
    {
         public int FirstPor {get; set;}
         public int LastPor {get; set;}
     }
     var ranges = (from r in SecondDatatable.Rows
                   select new Range
                     { 
                         FirstPor = Int32.Parse(r["FirstPor"]),
                         LastPor = Int32.Parse(r["LastPor"])
                      }).ToArray();
