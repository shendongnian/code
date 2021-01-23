    class Program
    {
        const string filename = @".\Example.xml";
        static void Main(string[] args)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(ListingDoc), new Type[] { typeof(Company), typeof(Area) });
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                // load from disk into object model
                ListingDoc listing = xSer.Deserialize(fs) as ListingDoc;
                // output loaded info
                listing.Areas.ForEach(area => Console.WriteLine("Area: {0}, {1}, {2}", area.Name, area.Sequence, area.Code));
                listing.Companies.ForEach(company => Console.WriteLine("Companies: {0}, {1}, {2}", company.Name, company.Rating, company.Parent));
            }
        }
    }
    public class ListingDoc
    {
        public List<Area> Areas;
        public List<Company> Companies;
    }
    public class Company
    {
        [XmlAttribute("Company_Rating")]
        public int Rating;
        [XmlAttribute("Company_Name")]
        public string Name;
        [XmlAttribute("Company_Parent")]
        public string Parent;
    }
    public class Area {
        [XmlAttribute("Area_Seq")]
        public int Sequence;
        [XmlAttribute("Area_Name")]
        public string Name;
        [XmlAttribute("Area_Code")]
        public string Code;
    }
