    <msxsl:script language="C#" implements-prefix="myns">
      <msxsl:assembly name="SgmlReaderDll, Version=1.8.11.0, Culture=neutral, PublicKeyToken=46b2db9ca481831b"/>
        <![CDATA[
     public XPathNodeIterator SGMLStringToXml(string strSGML)
     {
     Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
     sgmlReader.DocType = "HTML";
     sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
     sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
     sgmlReader.InputStream = new System.IO.StringReader(strSGML);
     // create document
     XmlDocument doc = new XmlDocument();
     doc.PreserveWhitespace = true;
     doc.XmlResolver = null;
     doc.Load(sgmlReader);
     return doc.CreateNavigator().Select("/*");
     }
     public string CurDir()
     {
     return (new System.IO.DirectoryInfo(".")).FullName;
     }
      ]]>
   
    </msxsl:script>
    <xsl:template match="node()" mode="PreventSelfClosingTags">
      <xsl:copy>
        <xsl:apply-templates select="@* | node()"/>
        <xsl:text> </xsl:text>
      </xsl:copy>
    </xsl:template>
    <xsl:template match="@*" mode="PreventSelfClosingTags">
      <xsl:copy>
        <xsl:apply-templates select="@* | node()"/>
      </xsl:copy>
    </xsl:template>
