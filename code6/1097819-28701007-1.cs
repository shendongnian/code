    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, XElement> lookupTable = new Dictionary<string, XElement>();
                Regex reg = new Regex(@"\<\!(?<TagName>.*)\!\>");
    
                XDocument doc = XDocument.Load("document.xml");
                XNamespace ns = doc.Root.GetNamespaceOfPrefix("w");
                IEnumerable<XElement> elements = doc.Root.Descendants(ns + "t").Where(x=> x.Value.StartsWith("<!")).ToArray();
                foreach (var item in elements)
                {
                    #region remove the grammar tag
                    //before
                    XElement grammar = item.Parent.PreviousNode as XElement;
                    grammar.Remove();
                    //after
                    grammar = item.Parent.NextNode as XElement;
                    grammar.Remove();
                    #endregion
                    #region merge the two nodes and insert the name and the XElement to the dictionary
                    XElement next = (item.Parent.NextNode as XElement).Element(ns + "t");
                    string totalTagName = string.Format("{0}{1}", item.Value, next.Value);
                    item.Parent.NextNode.Remove();
                    item.Value = totalTagName;
                    lookupTable.Add(reg.Match(totalTagName).Groups["TagName"].Value, item);
                    #endregion
                }
                foreach (var item in lookupTable)
                {
                    Console.WriteLine("The document contains a tag {0}" , item.Key);
                    Console.WriteLine(item.Value.ToString());
                }
    
               
            }
        }
    }
