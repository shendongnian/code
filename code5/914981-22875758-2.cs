    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace LinqToXmlDemo
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string xmlContent = GetXml();
                XDocument document = XDocument.Parse(xmlContent);
                
                XElement xe = FindPCName(document, "esc02");
                
                if (xe != null)
                {
                    xe.Add(new XElement("user_name", "DMS"));
                    Console.WriteLine(xe);
                }
                else
                {
                    Console.WriteLine("Query returned no results.");
                }
            }
            
            private static XElement FindPCName(XDocument document, String pcName)
            {
                IEnumerable<XElement> query =
                    from pc in document.Element("PCs").Elements("PC")
                    where pc.Element("pc_name").Value.Equals(pcName)
                    select pc;
                
                return query.FirstOrDefault();
            }
            
            private static String GetXml()
            {
                return
                    @"<?xml version='1.0' encoding='utf-8'?>
                      <PCs> 
                        <PC> 
                          <pc_name>esc01</pc_name> 
                          <pc_ip>10.10.10.10</pc_ip>
                          <pc_hwStatus>Working</pc_hwStatus>
                        </PC> 
                        <PC> 
                          <pc_name>esc02</pc_name>
                          <pc_ip>10.10.10.11</pc_ip> 
                          <pc_hwStatus>Under Maintenance</pc_hwStatus>
                        </PC>
                      </PCs>";
            }        
        }
    }
