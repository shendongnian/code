    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    namespace ConsoleApplication6
    {
       class Program
       {
           static void Main(string[] args)
           {
               DateTimeFormatInfo dateTimeInfo = new DateTimeFormatInfo();
               Console.Write(dateTimeInfo.GetAbbreviatedMonthName(4)); // Display April
               Console.ReadKey();
           }
       }
    }
