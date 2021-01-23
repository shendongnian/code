    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string text = "23/0212014";
            DateTime result;
            if (DateTime.TryParseExact(text, "dd/MM'1'yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Failed to parse");
            }
        }
    }
