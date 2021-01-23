    string badXml = @"
        <temproot>
            <Codepage>UTF16</Codepage>
            <Segment>0000016125
                <Control>0003┴300000┴English(U.S.)PORTUGUESE┴┴bla.000┴webgui\messages\xsl\en\blabla\blabla.xlf</Control>
                <Source>To blablablah the   firewall to blablablah local IP address.    </Source>
                <Target>Para blablablah a uma blablablah local específico.  </Target>
            </Segment>
        </temproot>";
    // assuming only <control> element has the invalid characters
    string goodXml = badXml
        .Replace("<Control>", "<Control><![CDATA[")
        .Replace("</Control>", "]]></Control>");
    XDocument xDoc = XDocument.Parse(goodXml);
    xDoc.Declaration = new XDeclaration("1.0", "utf-16", "yes");
    // do stuff with xDoc
