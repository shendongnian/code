    using System.IO;
    using System;
    using System.Collections.Generic;
        
        class Program
        {
            static void Main()
            {
                string digitsOnly = String.Empty;
                string s = "2323jh213j21h3j2k19hk";
               List<int> MyNumbers = new List<int>();
                foreach (char c in s)
                {
                  
                    if (c >= '0' && c <= '9') digitsOnly += c;
                    else
                    {
                         int NumberToSave;
        
                          bool IsIntValue = Int32.TryParse(digitsOnly, out NumberToSave);
                        
                          if (IsIntValue)
                          {
                             MyNumbers.Add(Convert.ToInt16(digitsOnly));
                          }
                        
                       
                       
                        digitsOnly=String.Empty;
                    }
                }
                
                foreach (int element in MyNumbers)
                    {
                      Console.WriteLine(element);
                    }
               
               
            }
        }
