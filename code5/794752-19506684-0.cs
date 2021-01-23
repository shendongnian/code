       private static void Main(string[] args)
        {
            try
            {
                XmlDocument xml1 = new XmlDocument();
                xml1.Load(@"C:\testxml\MainFile.xml");
                XPathNavigator nav = xml1.CreateNavigator();
                //Create the langFile Navigator
                XPathDocument xml2 = new XPathDocument(@"C:\testxml\LangFile.xml");
                XPathNavigator nav2 = xml2.CreateNavigator();
                //Select all text nodes.
                var nodes = nav2.SelectDescendants(XPathNodeType.Text, true);
                while (nodes.MoveNext())
                {
                    //Update the MainFile with the values in the LangFile
                    
                    var c = nav.SelectSingleNode(GetPath(nodes.Clone().Current));//(1*)
                    if(c != null)
                    {
                        c.MoveToFirstChild();
                        c.SetValue(nodes.Current.Value);
                    }
                }
                Console.WriteLine(xml1.InnerXml);
                Console.ReadKey();
            }
            catch
            {
            }
        }
        private static string GetPath(XPathNavigator navigator)
        {
            string aux =string.Empty;
            while (navigator.MoveToParent())
            {
                aux = navigator.Name + "/"+aux;
            }
            return "/" + (aux.EndsWith("/")?aux.Remove(aux.LastIndexOf('/')):aux);
        }
