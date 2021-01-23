            static void Main(string[] args)
            {
                string input =
                    "<a>" +
                       "<b>" +
                          "<c>val1</c>" +
                          "<d>val2</d>" +
                       "</b>" +
                       "<e>val3</e>" +
                       "<f>val4</f>" +
                   "</a>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(input);
                RecursiveRead(doc.DocumentElement);
     
            }
            static string RecursiveRead(XmlNode node)
            {
                List<string> children = new List<string>();
                bool done = false;
                if (node.HasChildNodes)
                {
                    foreach (XmlNode child in node)
                    {
                        children.Add(RecursiveRead(child));
                    }
                    Console.WriteLine("table : {0}; children : {1}", node.Name, string.Join(",", children.ToArray()));
                    //string cmd = "INSERT INTO " + second + " (" + first + ") VALUES ('" + xml.Value + "')";
                    //SqlCommand command = new SqlCommand(cmd, conn);
                    //command.ExecuteNonQuery();
                }
                else
                {
                    return node.Value;
                }
                return node.Name;
            }
            
