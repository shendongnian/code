    var xdoc = XDocument.Parse(@"<TestSuite><TestCase Name=""Connect""><Input>
     <AppName>XYZ</AppName><UserId>Vishwas</UserId></Input></TestCase>
     <TestCase Name=""Create""><Input><FileName>abc</FileName></Input><OutPut>
     <Filesize></Filesize></OutPut></TestCase></TestSuite>");
    string userid = (xdoc.Descendants("TestCase")
                         .Where(x => (string)x.Attribute("Name") == "Connect")
                         .Select(x => (string)x.Element("Input").Element("UserId")))
                         .FirstOrDefault();
