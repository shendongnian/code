    static void Main(string[] args)
    {
    
        XElement file1 = XElement.Parse(@"<?xml version='1.0' encoding='utf-8'?> 
            <Contentname>
                <Body>
                    <Content action='Hello'>
                        <Data type='Yellow'>
                        </Data>
                    </Content>
    
                    <Content action='Hello'>
                        <Data type='Red'>
                        <Status xmlns='http://2010-10-10/'>
                            <Id >39681</Id>
                            <Name>Published</Name>
                        </Status>
                    </Data>
                    </Content>
    
                    <Content action='Hello'>
                    <Data type='green'>
                        <Document>
                        <country>1</country>   
                        </Document>
                    </Data>
                    </Content>
                </Body>
            </Contentname>");
        XElement file2 = XElement.Parse(@"<?xml version='1.0' encoding='utf-8'?> 
            <Contentname>
                <Body>
                    <Content action='Hello'>
                        <Data type='Yellow'>
                        </Data>
                    </Content>
    
                    <Content action='Hello'>
                        <Data type='Red'>
                        <Status xmlns='http://2010-10-10/'>
                            <Id >39681</Id>
                            <Name>Published</Name>
                        </Status>
                    </Data>
                    </Content>
    
                    <Content action='Hello'>
                    <Data type='green'>
                        <Document>
                        <Name>XYZ</Name>   
                        </Document>
                    </Data>
                    </Content>
                </Body>
            </Contentname>");
    
    
        List<XElement> roots = new List<XElement> {file1, file2};
        foreach (var root in roots)
        {
    
            var nodesCountry = root.XPathSelectElements("Body/Content[@action='Hello']/Data[@type='green']/Document/country");
            var nodesName = root.XPathSelectElements("Body/Content[@action='Hello']/Data[@type='green']/Document/Name");
    
    
            foreach (var item in nodesName)
            {
                       
                Console.WriteLine("Name value={0}", item.Value );
            }
            foreach (var item in nodesCountry)
            {
                Console.WriteLine("Country value={0}", item.Value);
            }
        }
        Console.ReadLine();
    }
