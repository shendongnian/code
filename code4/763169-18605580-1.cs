    string xmlFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Candidates.xml");
    xmldoc = new XmlDocument();
    xmldoc.Load(xmlFile);
    root = xmldoc.DocumentElement;
    try
    {
        XmlNode CandidateNode = xmldoc.CreateNode(XmlNodeType.Element, "Candidate", "");
        XmlNode id = xmldoc.CreateNode(XmlNodeType.Element, "CandidateId", "");
        id.InnerText = "1";
        CandidateNode.AppendChild(id);
        XmlNode subPositionId = xmldoc.CreateNode(XmlNodeType.Element, "SubPositionId", "");
        subPositionId.InnerText = candidate.PositionId.ToString();
        CandidateNode.AppendChild(subPositionId);
        XmlNode firstName = xmldoc.CreateNode(XmlNodeType.Element, "FirstName", "");
        firstName.InnerText = candidate.FirstName;
        XmlNode lastName = xmldoc.CreateNode(XmlNodeType.Element, "LastName", "");
        lastName.InnerText = candidate.LastName;
        CandidateNode.AppendChild(firstName);
        CandidateNode.AppendChild(lastName);
        root.AppendChild(CandidateNode);
        xmldoc.Save(xmlFile);
 
