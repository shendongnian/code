    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    namespace WaitForIt
    {
        class Program
        {
            static void Main(string[] args)
            {
                string thexml = @"<Response xmlns=""http://tempuri.org/""><Result xmlns:a=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><a:string>18c03787-9222-4c9b-8f39-44c2b39c788e</a:string><a:string>774d38d2-a350-4711-8674-b69404283448</a:string></Result></Response>";
            
            XDocument doc = XDocument.Parse(thexml);
            XNamespace ns = "http://tempuri.org/";
            var result = doc.Descendants(ns + "Result");
            var resultStrings = result.Elements();
            foreach (var el in resultStrings)
            {
                Debug.WriteLine(el.Value);
            }
            
            // output:
            // 18c03787-9222-4c9b-8f39-44c2b39c788e
            // 774d38d2-a350-4711-8674-b69404283448
         }        
       }
    }
