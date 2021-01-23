    static void Create_Filled_XML() {
        XmlDocument doc = new XmlDocument();
        doc.XmlResolver = null;
        try {
            string docType = "";
            foreach(KeyValuePair<string, DocEntity> pair in CommandMapper.SymbolMap)
                    docType += pair.Value.GetEntityString();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlDocumentType myDocType = doc.CreateDocumentType("my_entities", null, null, docType);
            XmlProcessingInstruction xslStyle = doc.CreateProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"03_bibtex.xsl\"");
            XmlNode root = doc.CreateElement("bibtext");
            foreach(BibElement bib in bibtex) {
                root.AppendChild(bib.GetXml(doc));
            }
            doc.AppendChild(dec);
            doc.AppendChild(myDocType);
            doc.AppendChild(xslStyle);
            doc.AppendChild(root);
            doc.Save(@"...\file.xml");
        } catch(Exception ex) {
            Console.WriteLine();
        }
    }
