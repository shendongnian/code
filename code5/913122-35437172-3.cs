    using System;
    using System.IO;
    public class Program
    {
        public static void Main( )
        {
            try
            {
                try
                {
                    var num = int.Parse("abc"); // Throws FormatException               
                }
                catch ( FormatException fe )
                {
                    try
                    {
                        var openLog = File.Open("DoesNotExist", FileMode.Open);
                    }
                    catch
                    {
                        throw new FileNotFoundException("NestedExceptionMessage: File `DoesNotExist` not found.", fe );
                    }                              
                }
            }
            // Consider what exception is thrown: FormatException or FileNotFoundException?
            catch ( FormatException fe)
            {
                // FormatException isn't caught because it's stored "inside" the FileNotFoundException
            }
            catch ( FileNotFoundException fnfe ) 
            {
                string inMes="", outMes;
                if (fnfe.InnerException != null)
                    inMes = fnfe.InnerException.Message; // Inner exception (FormatException) message
                outMes = fnfe.Message;
                Console.WriteLine($"Inner Exception:\n\t{inMes}");
                Console.WriteLine($"Outter Exception:\n\t{outMes}");
            }        
        }
    }
