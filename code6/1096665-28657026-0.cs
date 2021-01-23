    static void Main(string[] args)
            {
                XmlTextReader xReader = new XmlTextReader(@"../../Ticket.xml");
                //xReader.WhitespaceHandling = WhitespaceHandling.None;
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xReader);
                //XmlNodeList xNodeList = xDoc.DocumentElement.SelectNodes("//Ticket/Tickets/@*");
                XmlNodeList elemList = xDoc.GetElementsByTagName("Destination");
                    for (int i = 0; i < elemList.Count; i++)
                        {
                            string attrVal = elemList[i].Attributes["location"].Value;
                            string elemVal = elemList[i].InnerText.ToString();
                            Console.WriteLine("Location: " + attrVal + " " + "Price: " + elemVal);
                            Console.ReadLine();
                        }  
            }
