    string asReadXml = @"<Data>
        <ParentID>00000000-0000-0000-0000-000000000000</ParentID>
        <Content>&lt;ContentControl xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""&gt; &lt;Grid&gt;&lt;Image Source="".//Resources/Images/start.png"" Tag=""Start"" ToolTip=""Start"" IsHitTestVisible=""False"" /&gt;&lt;/Grid&gt;&lt;/ContentControl&gt; </Content>
    </Data>";
    
    
    var fragment = Regex.Match(asReadXml, @"(?:\<Content\>)(?<Xml>.+)(?:\</Content\>)", RegexOptions.ExplicitCapture).Groups["Xml"].Value;
    
    var validFragment = Regex.Replace(Regex.Replace(fragment, "(&lt;)", "<"), "(&gt;)", ">");
    
    var xDoc = XDocument.Parse("<Root>" + validFragment + "</Root>");
    
    /* XDoc looks like this:
    
    <Root>
      <ContentControl xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
        <Grid>
          <Image Source=".//Resources/Images/start.png" Tag="Start" ToolTip="Start" IsHitTestVisible="False" />
        </Grid>
      </ContentControl>
    </Root>
    
    */
    
    var Image =
       xDoc.Root
           .Descendants()
           .Where (p => p.Name.LocalName == "Image")
           .First ();
    
    Console.WriteLine ( Image.Attribute("Tag").Value );
    
    // Outputs
    // Start
