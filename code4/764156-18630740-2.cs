    string xml = @"<xml>
    <person name=""a"">
      <age>21</age>
      <salary>50000</salary>
    </person>
    <person name=""b"">
      <age>25</age>
      <salary>30000</salary>
    </person>
    <person name=""c"">
      <age>30</age>
      <salary>60000</salary>
    </person>
    <person name=""d"">
      <age>35</age>
      <salary>150000</salary>
    </person>
    </xml>";
    using (var sr = new StringReader(xml))
    {
        var xml2 = XDocument.Load(sr, LoadOptions.SetLineInfo);
        foreach (var person in xml2.Root.Elements())
        {
            //string name = (string)person.Attribute("name"); // Unused
            int age = (int)person.Element("age");
            int salary = (int)person.Element("salary");
            // Your check
            bool error = salary > 50000 && age > 30;
            if (error)
            {
                // IMPORTANT PART HERE!!!
                int lineNumber = -1;
                int colNumber = -1;
                var lineInfo = (IXmlLineInfo)person;
                if (lineInfo.HasLineInfo())
                {
                    lineNumber = lineInfo.LineNumber;
                    colNumber = lineInfo.LinePosition;
                }
                return string.Format("Error on line {0}, col {1}", lineNumber, colNumber);
                // END IMPORTANT PART!!!
            }
        }
    }
