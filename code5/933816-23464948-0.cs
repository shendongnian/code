        private static string GetString(XmlNode root)
        {
            string retStr = "";
            XmlNodeList nodes = root.SelectNodes("imgdir");
            if (nodes.Count != 0)
            {
                foreach (XmlNode node in nodes)
                {
                    retStr=retStr+"\r\n"+GetString(node);
                }
            }
            else
            {
                string street = root.SelectSingleNode("string[@name='streetName']").Attributes["value"].Value;
                string map = root.SelectSingleNode("string[@name='mapName']").Attributes["value"].Value;
                string id = root.Attributes["name"].Value;
                retStr ="ID " + id+":"+"NAME "+root.ParentNode.Attributes["name"].Value+":"+ street + ":" + map;
            }
            return retStr;
        }
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Stack.xml");
            XmlNodeList nodes = doc.SelectNodes("imgdir/imgdir");
            foreach(XmlNode node in nodes)
            {
                Console.WriteLine(GetString(node));
            }
            Console.ReadLine();
        }
