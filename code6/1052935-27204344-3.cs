    var i = @"
         <Root>
          <Header>
            <ID>1</ID>
            <Name>Test</Name>
          </Header>
          <Body>
            <MetaDataSet>
                <ID>23568</ID>
                <Value>metadatavalue1</Value>
            </MetaDataSet>
          </Body>
        </Root>";
        
          var m = @"
          <MetaDataSet>
           <metadatasetvalue>Test</metadatasetvalue>
           <Valid>true</Valid>
        </MetaDataSet>
          ";
      var input2 = new XmlDocument();
      input2.Load(new StringReader(i));
      
      var meta2 = new XmlDocument();
      meta2.Load(new StringReader(m));
      
      var body2 = input2.SelectSingleNode("//Body");
      body2.InnerXml = meta2.DocumentElement.OuterXml;
      
      // helper to show the result
      sb = new StringBuilder();
      using(var xw = XmlWriter.Create(sb)) {
         input2.Save(xw);
      }
      sb.Dump("2");
