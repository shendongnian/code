    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    class LinqToXmlDemo
    {
        static public void Main(string[] args)
        {
            var xmlContent = GetXml();
            XDocument document = XDocument.Parse(xmlContent);
    
            var query =
                from property in
                    document.Descendants("OverXP").Elements("Property")
                select new
                {
                    Level = property.Ancestors().Count() - 1,
                    Actor = (string)property.Attribute("name"),
                    Value = (string)property.Attribute("value")
                };
    
            foreach (var item in query)
            {
                Console.WriteLine("[Level {0}] => [{1} = {2}]",
                                  item.Level, item.Actor, item.Value);
            }
        }
    
        static string GetXml()
        {
            return
                @"<VON>
                    <OverXP name='UML1'>
                        <Property name='actor1' value='1' />
                        <OverXP name='UML2'>
                            <Property name='actor2' value='2' />
                        </OverXP>
                    </OverXP>
                  </VON>";
        }
    }
