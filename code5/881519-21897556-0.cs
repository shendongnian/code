    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web.Http;
    using System.Web;
     namespace HTMLConsoleRead1._0
    {
    class Program
    
 
     { 
        static void Main(string[] args)
        
         {
         
            string htmlTitle = File.ReadAllText("masterHTML.html");
         
            Console.WriteLine(GetTitle(htmlTitle));
         
            Console.ReadLine();
            
        }
        static string GetTitle(string file)
        {
            Match match = Regex.Match(file, @"<title>\s*(.+?)\s*</title>");
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "";
            }
        }
    }
}
