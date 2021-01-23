    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.IO.Compression; //you will have to add a reference to System.IO.Compression.FileSystem(.dll)
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication28
    {
        public class MyWordDocument
        {
            #region fields
    
            private string fileName;
            private XDocument document;
            //todo: create fields for all document xml files that can contain the placeholders
    
            private Dictionary<string, List<XElement>> lookUpTable;
    
            #endregion
    
            #region properties
    
            public IEnumerable<string> Tags { get { return lookUpTable.Keys; } }
    
            #endregion
    
            #region construction
    
            public MyWordDocument(string fileName)
            {
                this.fileName = fileName;
                ExtractDocument();
                CreateLookUp();
            }
    
            #endregion
            #region methods
    
            public void ReplaceTagWithValue(string tagName, string value)
            {
                foreach (var item in lookUpTable[tagName])
                {
                    item.Value = item.Value.Replace(string.Format(@"<!{0}!>", tagName),value);
                }
            }
    
            public void Save(string fileName)
            {
                document.Save(@"temp\word\document.xml");
                //todo: save other parts of document here i.e. footer header or other stuff
               
                ZipFile.CreateFromDirectory("temp", fileName);
            }
    
            private void CreateLookUp()
            {
                //todo: make this work for all cases and for all files that can contain the placeholders
                //tip: open the raw document in word and replace the tags,
                //     save the file to different location and extract the xmlfiles of both versions and compare to see what you have to do
                lookUpTable = new Dictionary<string, List<XElement>>();
                Regex reg = new Regex(@"\<\!(?<TagName>.*)\!\>");
                document = XDocument.Load(@"temp\word\document.xml");
                XNamespace ns = document.Root.GetNamespaceOfPrefix("w");
                IEnumerable<XElement> elements = document.Root.Descendants(ns + "t").Where(x => x.Value.StartsWith("<!")).ToArray();
                foreach (var item in elements)
                {
                    XElement grammar = item.Parent.PreviousNode as XElement;
                    grammar.Remove();
                    grammar = item.Parent.NextNode as XElement;
                    grammar.Remove();
                    XElement next = (item.Parent.NextNode as XElement).Element(ns + "t");
                    string totalTagName = string.Format("{0}{1}", item.Value, next.Value);
                    item.Parent.NextNode.Remove();
                    item.Value = totalTagName;
                    string tagName = reg.Match(totalTagName).Groups["TagName"].Value;
                    if (lookUpTable.ContainsKey(tagName))
                    {
                        lookUpTable[tagName].Add(item);
                    }
                    else
                    {
                        lookUpTable.Add(tagName, new List<XElement> { item });
                    }
                }
            }
    
            private void ExtractDocument()
            {
                if (!Directory.Exists("temp"))
                {
                    Directory.CreateDirectory("temp");
                }
                else
                {
                    Directory.Delete("temp",true);
                    Directory.CreateDirectory("temp");
                }
                ZipFile.ExtractToDirectory(fileName, "temp");
            }
    
            #endregion
        }
    }
