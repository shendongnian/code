    using System;
    using System.Text;
    using System.Xml;
    
    public class Program
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
    
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><td>TYPTRT</td><td>CLAFCNO</td><td>NUMCLI</td><td>TYPACT</td></tr>");
    
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile2.xml");
    
            XmlNodeList rowElements = doc.SelectNodes("W-TIBCPTRs/W-TIBCPTR");
    
            foreach(XmlElement rowElement in rowElements)
            {
                sb.AppendLine("<tr>");
    
                foreach (XmlElement valueElement in rowElement.ChildNodes)
                {
                    
                    if (valueElement.GetAttribute("VALIDE") == "NON")
                        sb.AppendFormat("<td bgcolor='Red'>{0}</td>", valueElement.InnerText);
                    else
                        sb.AppendFormat("<td>{0}</td>", valueElement.InnerText);
                }
    
                sb.AppendLine("</tr>");
    
    
            }
    
            sb.AppendLine("</table>");
    
            Console.WriteLine(sb.ToString());
        } 
    }
