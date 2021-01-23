    public class TrainInfo
    {
        public string categoryRef { get; set; }
        public int trainNumber { get; set; }
        public string processStatus { get; set; }
        public string operatingPeriodRef { get; set; }
        public List<ocpsTTs> ocpsTT { get; set; }
    }
    public struct ocpsTTs
    {
        public string ocpType;
        public string ocpRef;
        public string arrival;
        public string departure;
        public string scope;
        public string trackInfo;
    }
    class Program
    {
        static void Main(string[] args)
        {
            TrainInfo ti = ProcessXml(@"XMLFile1.xml", 2);
        }
        static TrainInfo ProcessXml(string xmlfile, int trainnumber)
        {
            TrainInfo retVal;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlfile);
                XNamespace xns = "http://www.rail.org/schemas/2009";
                XDocument xdoc = System.Xml.Linq.XDocument.Parse(xmlDoc.InnerXml);
                retVal =
                    (from c
                     in xdoc.Root.Elements(xns + "timetable").Elements(xns + "trainParts").Elements(xns + "trainPart")
                     where c.Attribute("trainNumber").Value.Equals(trainnumber.ToString())
                     select new TrainInfo
                     {
                         categoryRef = c.Attribute("categoryRef").Value,
                         trainNumber = Int32.Parse(c.Attribute("trainNumber").Value),
                         processStatus = c.Attribute("processStatus").Value,
                         operatingPeriodRef = c.Element(xns + "operatingPeriodRef").Attribute("ref").Value,
                         ocpsTT = (from tt in c.Elements(xns + "ocpsTT").Descendants(xns + "ocpTT")
                                   select new ocpsTTs
                                   {
                                      ocpType = tt.Attribute("ocpType").Value,
                                      ocpRef = tt.Attribute("ocpRef").Value,
                                      arrival = tt.Elements(xns + "times").Any() ? tt.Element(xns + "times").Attribute("arrival").Value : string.Empty,
                                      departure = tt.Elements(xns + "times").Any() ? tt.Element(xns + "times").Attribute("departure").Value : string.Empty,
                                      scope = tt.Elements(xns + "times").Any() ? tt.Element(xns + "times").Attribute("scope").Value : string.Empty,
                                      trackInfo = tt.Element(xns + "sectionTT").Attribute("trackInfo").Value,
                                   }).ToList()
                     }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                retVal = null;
            }
            return retVal;
        }
    }
