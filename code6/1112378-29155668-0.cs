    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    class Program
    {
        static void Main(string[] args)
        {
            // slecting locale
            var ci = new CultureInfo("es-ES");
            
            // use a StringBuilder for storing the processed text
            var sBuilder = new StringBuilder();
            // use an Enumerable
            Enumerable.Range(-2, 5)
                // get date range
                .Select(i => DateTime.Today.AddDays(i))
                // get long dates in es-ES and remove ","
                .Select(i => i.ToString("D", ci).Replace(",", ""))
                .ToList().ForEach(s =>
                {
                    // capitalize first letter
                    sBuilder.Append(char.ToUpper(s[0]));
                    // remove the year part
                    sBuilder.Append(s.Substring(1, s.LastIndexOf(' ') - 3));
                    // add delimiter
                    sBuilder.Append("| ");
                });
            // adjust length for removing the final delimiter
            sBuilder.Length = sBuilder.Length - 2;
            Console.WriteLine(sBuilder.ToString());
        }
    }
