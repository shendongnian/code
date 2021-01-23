    string origXml = "<RATES ID=\"1\" RatesEffectivateDate=\"27/02/2014\">\n  <Type Name=\"Type1\" Code=\"A\">\n    <Del ID=\"D1\">\n      <Field1>10</Field1>\n      <Field2>20</Field2>\n      <Field3>30</Field3>\n      <Field4>40</Field4>\n    </Del>\n    <Del ID=\"D2\">\n      <Field1>50</Field1>\n      <Field2>60</Field2>\n      <Field3>70</Field3>\n      <Field4>80</Field4>\n    </Del>\n  </Type>\n  <Type Name=\"Type2\" Code=\"B\">\n    <Del ID=\"D1\">\n      <Field1>110</Field1>\n      <Field2>120</Field2>\n      <Field3>130</Field3>\n      <Field4>140</Field4>\n    </Del>\n    <Del ID=\"D3\">\n      <Field1>150</Field1>\n      <Field2>160</Field2>\n      <Field3>170</Field3>\n      <Field4>180</Field4>\n    </Del>\n  </Type>\n</RATES>";
    var xDoc = XDocument.Parse(origXml);
    
    var resDoc = new XDocument(
        new XElement("RATES",
                        xDoc.Element("RATES")
                            .Elements("Type")
                            .SelectMany(typeEl =>
                                        typeEl.Elements("Del")
                                            .SelectMany(delEl =>
                                                        delEl.Elements()
                                                            .Select(fieldEl =>
                                                                    new XElement("RATE",
                                                                                    new XElement("ID", typeEl.Attribute("Name").Value),
                                                                                    new XElement("Code", typeEl.Attribute("Code").Value),
                                                                                    new XElement("DelID", delEl.Attribute("ID").Value),
                                                                                    new XElement(fieldEl.Name, fieldEl.Value)))))
            ));
    
    resDoc.Save("transformedDoc.xml", SaveOptions.None);
