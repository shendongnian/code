     XDocument xd = null;
            using (StreamReader oReader = new StreamReader(xmlFilePath, Encoding.GetEncoding("ISO-8859-1")))
            {
                xd = XDocument.Load(oReader);
            }
     var records = from root in xd.Descendants("MessageBody")
                          from details in root.Elements("Details").Elements("Detail")
                          select new
                          {
                              AdjusterEmail = root.Element("AdjusterEmail").Value,
                              EmpCode = root.Element("MasterCarrierInfo").Element("EmployerCode").Value,
                              SOJ = root.Element("SOJ").Value,
                              DOI = root.Element("DOI").Value,
                              GPI = details.Element("GPI").Value,
                              BlockCode = details.Element("Blocks").Element("Block").Element("BlockCode").Value
                              
                          };
