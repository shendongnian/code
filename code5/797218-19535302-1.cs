    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Url for Sample.xml");
    
                XmlNodeList elemList = doc.GetElementsByTagName("rect");
                for (int i = 0; i < elemList.Count; i++)
                {
                    string attrVal = elemList[i].Attributes["label"].Value;
                    Console.WriteLine(attrVal);
                }
                Console.ReadLine();
            }
        }
    }
