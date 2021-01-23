        string[] ReportTableHeader = { "Headerone", "HeaderTwo", "HeaderTwo"};
    
    
    XDocument xdoc = new XDocument(new XElement("ReportTable",
                            new XElement("Node1", headerText1),
                            new XElement("Node2", headerText2),
                            new XElement("Node3",headerText3),
                            new XElement("Node4",headerText4),
                            new XElement("CurrentDate", footerCurDate),
                            new XElement("Columns", from col in ReportTableHeader
                                                                  select
                                                                      new XElement("Column", new XAttribute("ColName", col.ToString().Trim())))));
    XDocument finalXDoc = new XDocument();
                        using (XmlWriter inputStreamXSLT = finalXDoc.CreateWriter())
                        {
                            XslCompiledTransform objXSLT = new XslCompiledTransform();
                            string xsltFilePath = Server.MapPath(BasePage.GetReportPath(formName));
                            objXSLT.Load(xsltFilePath);
                            objXSLT.Transform(xdoc.CreateReader(), inputStreamXSLT);
                        }
                        string inputXMLtoXSLT = finalXDoc.ToString();
