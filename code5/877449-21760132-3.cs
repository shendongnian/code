    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            string [] lines = new string[2];
            lines[0] = "John, 12345, true";
            lines[1] = "Miles, 45678, true";
    
            var o = from x in lines
                    let eachLine = x.Split(',')
                    select new {
                        name = eachLine[0],
                        zip  = Int32.Parse(eachLine[1]),
                        status = bool.Parse(eachLine[2])
                    };
            foreach (var p in o) {
                Console.WriteLine(p.name + " - " + p.zip + ", - " + p.status);
            }
        }
    }
