    var MyC1Nodes = new List<string>();
    var MySerialNodes = new List<string>();
    var MyXml = new XmlDocument();
    MyXml.LoadXml(File.ReadAllText(@"pathOfXml").ToString());
                    foreach (XmlNode tempSerialNo in MyXml.DocumentElement.SelectNodes("//@SerialNo"))
                    {
                        MySerialNodes.Nodes.Add(tempSerialNo.Value.ToString());
                    }
    
                    foreach (XmlNode tempC1 in MyXml.DocumentElement.SelectNodes("//@c1"))
                    {
                        MyC1Nodes.Add(TempC1.Value.ToString());
                    }
