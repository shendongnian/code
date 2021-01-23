    using System.Xml;
    using System.Xml.Linq;
    static void Main(string[] args) {
    // This txt file contains your xml.
    var xml_sample = File.ReadAllText("xml_sample.txt");
    var doc = XDocument.Parse(xml_sample);
    
    // Get all <CustomFieldValueSet> that have the label attribute `Account`
    var accounts = from item in doc.Descendants("Codes").Descendants("CustomFieldValueSet")
                   where (item.HasAttributes) && 
                         (item.Attribute("label").Value == "Account")
                   select item;
    
    // Create an anonymous type containing the value of the 
    // distributionValue attribute and the <Value> node.
    var accountValue = from el in accounts.Descendants("CustomFieldValue")
                       let distAttribute = el.Attribute("distributionValue")
                       select new
                       {
                           distValue = distAttribute != null ? distAttribute.Value : "0",
                           value = el.Descendants("Value").First().Value,
                       };
    
    // Display stuff here just to make sure we got it right.
    accounts.ToList().ForEach(el => 
        Console.WriteLine(el.Name + " " + el.Attribute("distributionType").Value));
    
    accountValue.ToList().ForEach(el => 
        Console.WriteLine(el.distValue + ":"+ el.value));
    }
