    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    namespace XMLUpdate
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("In Execute..");
                string SourceFile = args[0];
                string TargetFile = args[1];
                string SourcePackageId = null;
                string SourcePackageVersion = null;
                XmlDocument SourceXmlDoc = new XmlDocument();
                XmlDocument TargetXmlDoc = new XmlDocument();
                SourceXmlDoc.Load(SourceFile);
                TargetXmlDoc.Load(TargetFile);
                XmlElement SourceRootElement = SourceXmlDoc.DocumentElement;
                //XmlElement SourceElement = SourceRootElement["packages"];
                XmlNodeList SourcexnList = SourceXmlDoc.SelectNodes("/packages");
                foreach (XmlNode Sourcexn in SourcexnList)
                {
                    Console.WriteLine("In source loop..");
                    foreach(XmlNode childS in Sourcexn.ChildNodes)
                    {
                        SourcePackageId = childS.Attributes["id"].InnerText;
                        SourcePackageVersion = childS.Attributes["version"].InnerText;
                        Console.WriteLine("In source loop SourcePackageId.." + SourcePackageId);
                        XmlElement TargetRootElement = TargetXmlDoc.DocumentElement;
                        XmlNodeList TargetxnList = TargetXmlDoc.SelectNodes("/packages");
                        foreach (XmlNode Targetxn in TargetxnList)
                        {
                            Console.WriteLine("In Target loop..");
                            foreach (XmlNode childT in Targetxn.ChildNodes)
                            {
                                string TargetPackageId = childT.Attributes["id"].InnerText;
                                if (SourcePackageId.Equals(TargetPackageId))
                                {
                                    childT.Attributes["version"].InnerText = SourcePackageVersion;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
