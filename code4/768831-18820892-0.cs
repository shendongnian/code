    ...
        doc.LoadXml(CreateXmaData(XDocument.Parse(xfa.DomDocument.InnerXml)));
        PdfAction readOnlyAction = PdfAction
             .JavaScript(MakeReadOnly(xfa.DomDocument.InnerXml), stamper.Writer);
        stamper.Writer.AddJavaScript(readOnlyAction);
        xfa.DomDocument = doc;
    ...
        private string MakeReadOnly(string xml) 
        {
            string formName = string.Empty;
            int subFormStart = xml.IndexOf("<subform", 0);
            if (subFormStart > -1)
            {
                int nameTagStart = xml.IndexOf("name", subFormStart);
                int nameStart = xml.IndexOf("\"", nameTagStart);
                int nameEnd = xml.IndexOf("\"", nameStart + 1);
                formName = xml.Substring(nameStart + 1, (nameEnd - nameStart) - 1);
            }
            string readOnlyFunction = "ProcessAllFields(xfa.form." + formName + ");";
            readOnlyFunction += "function ProcessAllFields(oNode) {";
            readOnlyFunction += " if (oNode.className == \"exclGroup\" || oNode.className == \"subform\"  || oNode.className == \"subformSet\" || oNode.className == \"area\") { ";
	    	readOnlyFunction += "  for (var i = 0; i < oNode.nodes.length; i++) {";
            readOnlyFunction += "   var oChildNode = oNode.nodes.item(i); ProcessAllFields(oChildNode);";
            readOnlyFunction += "  }";
            readOnlyFunction += " } else if (oNode.className == \"field\") {";
            readOnlyFunction += "  oNode.access = \"readOnly\"";
            readOnlyFunction += " }";
            readOnlyFunction += "}";
            return readOnlyFunction;
        }
