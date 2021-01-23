    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Program
    {
        public static void Main()
        {
            XDocument xDocument =
                XDocument.Load(@"C:\Visual Studio\Projects\ConsoleApplication3\ConsoleApplication3\config.xml");
    
            if (xDocument != null)
            {
                var locators = from x in xDocument.Descendants("add")
                    where !x.Attribute("key").Value.EndsWith("Ctrl")
                    select x;
    
                if (locators.Any())
                {
                    foreach (var locator in locators)
                    {
                        var controller = from c in xDocument.Descendants("add")
                            where
                                c.Attribute("key")
                                    .Value.Equals(locator.Attribute("key").Value + "ctrl",
                                        StringComparison.CurrentCultureIgnoreCase) 
                            select c;
    
                        if (controller.Any())
                        {
                            Console.WriteLine(controller.First().Attribute("value"));
                        }
    
                    }
    
                   
                }
            }
        }
    }
