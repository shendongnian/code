    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
        using Newtonsoft.Json;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                string jsonString =
                    "["
                    + "{"
                    + " \"error\": "
                    + "     {" 
                    + "         \"typeofdevice\": 678,"
                    + "         \"valueconvert\": \"\"," 
                    + "         \"message\": \"oops something went wrong\"" 
                    + "     }" 
                    + "}" 
                  + "]";
    
                List<Data> data = JsonConvert.DeserializeObject<List<Data>>(jsonString);
                Console.WriteLine(data[0].Error.typeofdevice);
            }
    
            public class Data
            {
                public Error Error { get; set; }
            }
    
            public class Error
            {
    
                public string typeofdevice { get; set; }
                public string valueconvert { get; set; }
                public string message { get; set; }
            }
        }
    }
