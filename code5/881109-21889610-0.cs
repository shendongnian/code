    var pdf = new Aspose.Pdf.Generator.Pdf();
    pdf.IsLandscape = true;
    
    Aspose.Pdf.Generator.Section section = pdf.Sections.Add();
    Aspose.Pdf.Generator.Text text = new Aspose.Pdf.Generator.Text(section, htmlString);
    text.IsHtmlTagSupported = true;
    text.IsHtml5Supported = true;
    text.TextInfo.FontName = "Arial Unicode MS";
    text.IfHtmlTagSupportedOverwriteHtmlFontNames = true;
    section.Paragraphs.Add(text);
    pdf.SetUnicode();
    
    pdf.Save(fullFilePath);
