    var input = @"
    <root>
      <someTag fontSize=""16"" />
      <someTag otherAttribute=""12"" />
    </root>";
    
    var doc = XDocument.Parse(input);
    
    var allAttributes = doc.Descendants().Attributes();
    
    var fontSizeAttributes = allAttributes.Where(x => x.Name == "fontSize");
    
    foreach (var f in fontSizeAttributes)
        f.Value = Regex.Replace(f.Value, "^([0-9].)$", "$1px");
