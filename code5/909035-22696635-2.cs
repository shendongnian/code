    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                p.parse();
            }
    
    
            XmlDocument xmldoc = new XmlDocument();
    
            public void parse()
            {
                xmldoc.Load("c:\\yourfile.xml");//load your XML file
    
                //set your starting point
                XmlNodeList xNodelset = xmldoc.DocumentElement.SelectNodes("EXAM");
    
                // traverse the XML 
                foreach (XmlNode xNode in xNodelset)
                {
                    //here's where all the work is done: you can go over nodes, get their value
                    
                    
                    //get the exam id attribute:
                    int examID = int.Parse(xNode.Attributes[0].Value);
    
                    //and eventually push them to your DB using SQL.
                }
            }
        }
    
        
    }
