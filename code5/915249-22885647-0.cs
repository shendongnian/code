    using System;
    using System.Text;
    using System.Xml;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static string GetText(string xmlFragment)
            {
                XmlTextReader tr = new XmlTextReader(xmlFragment, XmlNodeType.Element, null);
    
                while (tr.Read())
                {
                    if (tr.NodeType == XmlNodeType.Text)
                    {
                        return tr.Value;
                    }
                }
    
                return "";
            }
    
            static void Main(string[] args)
            {
                string s = "<A id=\"ctl00_ctl00_ctl00_BodyContent_ContentPlaceHolder1_MainContentPlaceHolder_ResourceHostControl1_resContainer_rptColumn1_ctl00_ctl00_wrapper_downNodesTable_ctl01_ToolsetLink1\" href=\"/Orion/NetPerfMon/NodeDetails.aspx?NetObject=N:78\">SFTP</A>";
                Console.WriteLine(GetText(s)); // outputs "SFTP"
                Console.ReadLine();
            }
        }
    }
    
