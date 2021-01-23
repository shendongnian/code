     XDocument xd = null;
            using (StreamReader oReader = new StreamReader(xmlFilePath, Encoding.GetEncoding("ISO-8859-1")))
            {
                xd = XDocument.Load(oReader);
            }
    var records = from root in xd.Descendants("MessageBody")
                          select new
                          {
                              AdjusterEmail = root.Element("AdjusterEmail").Value,
                              EmpCode = root.Element("MasterCarrierInfo").Element("EmployerCode").Value,
                              SOJ = root.Element("SOJ").Value,
                              DOI = root.Element("DOI").Value,
                              GPI = root.Element("Details").Element("Detail").Element("GPI").Value,
                              BlockCode = root.Element("Details").Element("Detail").Element("Blocks").Element("Block").Element("BlockCode").Value
                          };
