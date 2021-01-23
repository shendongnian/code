            XDocument xdoc = <add your code to get xml from url>;
            var ns = xdoc.Root.GetDefaultNamespace();
            var cityList = from query in xdoc.Descendants(ns + "city")
                             select new CityItem
                             {
                                 Date = (string)query.Element(ns + "date").Attribute("value").Value,
                                 Time = (string)query.Element(ns + "time").Attribute("value").Value
                             };
            public class CityItem
            {
                public string Date {get;set;}
                public string Time {get;set;}
            }
