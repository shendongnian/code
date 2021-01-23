    using System.Xml;
    using System.Xml.Linq;
    static void Main(string[] args) {
    var xml_sample = File.ReadAllText("xml_sample.txt");
    var doc = XDocument.Parse(xml_sample);
    
    var accounts = from item in doc.Descendants("Codes").Descendants("CustomFieldValueSet")
                              where (item.HasAttributes) && 
                                    (item.Attribute("label").Value == "Account")
                              select item;
    
    var accountValue = from el in accounts.Descendants("CustomFieldValue")
                       select new
                       {
                           distValue = el.Attribute("distributionValue").Value,
                           value = el.Descendants("Value").First().Value,
                       };
    
    accounts.ToList().ForEach(el => Console.WriteLine(el.Name + " " + el.Attribute("distributionType").Value));
    
    accountValue.ToList().ForEach(el => Console.WriteLine(el.distValue + ":"+ el.value));
    }
