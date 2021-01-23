    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace RegexTester
    {
        class Program
        {
            static string text = @"FIRST NOTICE                         COMPANYNAME
     NOTICE DATE....: 01/01/2001          1111 N NORTHWOOD DR
     NUMBER.........: 11-1-11111-1        SOMEWHERE WY 05920-5929
     THE DATE.......: 02/01/2001
    
     Some data only.
    
    
    
    
    
    
    
          DOEN, JOHN THOMAS                           ORIGINAL....:      5789.00
          1111 N WALT AVE                             BALANCE.....:      1000.00
          C/O SOMEONE ELSE                            PAST DUE....:       500.00
          SOMEWHERE WY 04741-5555
    
     THIS IS THE END OF THIS PAGE                     DATE DUE: 02/01/2001
     FIRST NOTICE                         COMPANYNAME
     NOTICE DATE....: 01/01/2001          1111 N NORTHWOOD DR
     NUMBER.........: 22-2-22222-2        SOMEWHERE WY 05920-5929
     THE DATE.......: 02/01/2001
    
     Some data only.
    
    
    
    
    
    
    
          DOE, JOHNAT ZOAR                            ORIGINAL....:      2211.00
          11111 N DIVISOR RD                          BALANCE.....:      2000.00
          SOMWEHERE WY 05922                          PAST DUE....:      1000.00
    
    
     THIS IS THE END OF THIS PAGE                     DATE DUE: 02/01/2001";
    
            static void Main(string[] args)
            {
                string pattern = @"^[A-Z, ]+(?=original...)|^[A-Z, 0-9]+(?=balance...)|^[//A-Z, 0-9]+(?=past due...)|^[^\n\.]{2,50}(?=\n\s+\n^\s+THIS IS THE END OF THIS PAGE)";
                Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(text);
                List<string> cleaned = matches.Cast<Match>().Select(x => x.Value.Trim()).ToList();
            }
        }
    }
