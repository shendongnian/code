    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Xsl;
    
    namespace XSLPlayPlace
    {
        class Program
        {
            static void Main(string[] args)
            {
                string stylesheetText = File.ReadAllText("stylesheet.xsl");
    
                var program =
                    new Program().transformXML("<data><item>1</item><item>2</item><item>19</item><item>1</item></data>", stylesheetText);
            }
    
            private string transformXML(string xml_data, string xml_style)
            {
                [... snip ... your code copied exactly as per the question ...]
            }
        }
    }
