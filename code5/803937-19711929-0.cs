    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace GetMaxXMLDepth
    {
        class Program
        {
            static void Main(string[] args)
            {
                string doc = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <general>
        <settings>
            <resolution>1920x1080</resolution>
            <version>1.0</version>
        </settings>
        <data>
            <persons>
                <person>
                    <name>Bob</name>
                    <age>41</age>
                </person>
                <person>
                    <name>Alex</name>
                    <age>25</age>
    <things><stuff/></things>
                </person>
            </persons>
        </data>
    </general>";
                var xd = XDocument.Parse(doc);
    
                int maxDepth = GetMaxChildDepth(xd.Root);
            }
    
            static int GetMaxChildDepth(XElement element)
            {
                int result = 1;
    
                //always return 1 as the root node has depth of 1.
                //in addition, return the maximum depth returned by this method called on all the children.
                if (element.HasElements)
                    result += element.Elements().Max(p => GetMaxChildDepth(p));
    
                return result;
            }
        }
    }
