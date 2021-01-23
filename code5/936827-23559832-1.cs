    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement xElement = XElement.Parse(@"<?xml version=""1.0"" encoding=""utf-8""?>
    <attributes>
    
    <!--
        Attribute mapping file defines mapping between AVEVA PID attribute name and        corresponding 
    AVEVA NET Characteristic name.-->
    <!-- Don't output off-sheet pipe connector characteristics to the EIWM registry file   <drawing>_avngate.xml -->
    <attribute class=""PIPE CONNECTION FLAGBACKWARD"" from=""Grid_Reference"" output=""false""/>
    <attribute class=""PIPE CONNECTION FLAGBACKWARD"" from=""PipeId"" output=""false""/>
    <attribute class=""All"" from=""TagSuffix"" output=""false""/>
    </attributes>");
                var fstElement = xElement.FirstNode;
                int i = 0; 
                do
                {
                    if (fstElement.NodeType != XmlNodeType.Comment)
                    {
                        if (fstElement.Parent != null)
                        {
                            
                            fstElement.Remove();
                            i--;       
                        }
                    }
                    i++;  
    
                } while ( i< xElement.Nodes().Count() && (fstElement = xElement.Nodes().ToArray()[i]) != null);
                
    
                Console.WriteLine(xElement);
    
    
            }
        }
    }
