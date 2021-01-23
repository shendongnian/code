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
                    var num = int.Parse("abc");                
                }
                catch ( Exception inner )
                {
                    try
                    {
                        var openLog = File.Open("DoesNotExist", FileMode.Open);
                    }
                    catch
                    {
                        throw new FileNotFoundException("OutterException", inner);
                    }                              
                }
            }
            catch ( Exception e)
            {
                string inMes, outMes;
                if (e.InnerException != null)
                    inMes = e.InnerException.Message;
                outMes = e.Message;
            }        
        }
    }
