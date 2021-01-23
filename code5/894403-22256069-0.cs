    using System;
    using System.Globalization;
    namespace ConsoleApplication 
    {
        class Program
        {
            static void Main(string[] args)
            {
                string dateString, format;
                DateTime result;
                CultureInfo provider = CultureInfo.InvariantCulture;
                dateString = "2010-12-25T05:05:05.888";
                format = "yyyy-MM-dd'T'HH:mm:ss.fff";
                try
                {
                    result = DateTime.ParseExact(dateString, format, provider);
                    Console.WriteLine("{0} converts to {1}.", dateString, result.ToString());
                    Console.WriteLine(result.Millisecond);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.StackTrace);
                    Console.WriteLine("{0} is not in the correct format", dateString);
                }
            }
        }
    }
