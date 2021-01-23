    using System.Xml.Linq;
    static void Main()
    {
       var xml = "<Data><ININDIA>WEST BENGAL</ININDIA><ININDIA>KOLKATA</ININDIA></Data>";
       var xd = XDocument.Parse(xml);
       //get all `XElement` objects with the name "ININDIA"
       foreach (var e in xd.Root.Descendants()
            .Where(e=>e.Name.LocalName=="ININDIA"))
        {
          Console.WriteLine(e.Value);
        }
    }
