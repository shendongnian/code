    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace XMLToDictionary
    {
        class Program
        {
            static void Main(string[] args)
            {
                var doc = XDocument.Load("c:\\Test.xml");
    
                var clients = doc.Descendants().Where(e => e.Name.LocalName == "Client").ToList();
                Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                foreach (var client in clients)
                {
                    string key = client.Elements().First(e => e.Name.LocalName == "Name").Value;
                    string val = client.Elements().First(e => e.Name.LocalName == "Value").Value;
                    if (!dic.ContainsKey(key))
                    {
                        dic[key] = new List<string>();
                    }
                    dic[key].Add(val);
                }
    
    
            }
        }
    }
