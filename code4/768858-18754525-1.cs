    var allDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var @base = allDigits.Length;
    var a = new StringBuilder();
    var start = 2176782336;  // minimum 6 digit base36 number
    var end = 76187381759;   // maximum 6 digit base36 number
    
    Enumerable.Range(1, 1000)
              .Select(n => {
                               int r;
                               var d = n + start;
                               a.Clear();
                               do
                               {
                                   r = (int)(d % @base);
                                   d = d / @base;
                                   a.Insert(0, allDigits[r]);
                               } while(d >= @base);
                               
                               a.Insert(0, allDigits[r]);
                               return a.ToString();
                           })
              .Dump();
