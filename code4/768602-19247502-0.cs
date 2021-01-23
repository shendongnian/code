    public XmlNamespaceManager NamespaceManager { get; set; }
    public XPathNavigator Navigator { get; set; }
    public SuperDuperXMLQueryingClass(System.IO.Stream stream)
            {
                var namespaces = RetrieveNameSpaceMapFromXml(XDocument.Load(stream).Root);
                Navigator = new XPathDocument(stream).CreateNavigator();
                NamespaceManager = new XmlNamespaceManager(Navigator.NameTable);
                
                foreach (var t in namespaces)
                {
                    NamespaceManager.AddNamespace(t.Key, t.Value.NamespaceName);
                }
            }
    // LINQ to XML mostly used here.
    private static Dictionary<string, XNamespace> RetrieveNamespaceMapFromXDocumentRoot(XElement root)
            {
                if (root == null)
                { throw new ArgumentNullException("root"); }
    
                return root.Attributes().Where(a => a.IsNamespaceDeclaration)
                                         .GroupBy(a => (
                                                            a.Name.Namespace == XNamespace.None ? String.Empty : a.Name.LocalName),
                                                            a => XNamespace.Get(a.Value)
                                                        )
                                         .Where(g => g.Key != string.Empty)
                                         .ToDictionary(g => g.Key, g => g.First());
            }
    public string DeliverFirstValueFromXPathQuery(string qry)
            {
                try
                {
                    var iter = QueryXPathNavigatorUsingShortNamespaces(qry).GetEnumerator();
                    iter.MoveNext();
                    return iter.Current == null ? string.Empty : iter.Current.ToString();
                }
                catch (InvalidOperationException ex)
                {
                    return "";
                }
            }
