      using DocumentFormat.OpenXml.Wordprocessing;
      using DocumentFormat.OpenXml.Packaging;
      // read-only open 
      using (var document = WordprocessingDocument.Open(@"Your.docx", false))
      {
       // Gets the MainDocumentPart of the WordprocessingDocument 
       var main = document.MainDocumentPart;
        // document fonts
        var fonts = main.FontTablePart;
        // document styles
        var styles = main.StyleDefinitionsPart;
        var effects = main.StylesWithEffectsPart;
        // root element part of the doc
        var doc = main.Document;
        // actual document body
        var body = doc.Body;
        // styles on paragraps
        foreach (Paragraph para in body.Descendants<Paragraph>()
          .Where(e => e.ParagraphProperties != null&& e.ParagraphProperties.ParagraphStyleId != null))
          Console.WriteLine("Text:{0}->Style name:{1}", para.InnerText, para.ParagraphProperties.ParagraphStyleId.Val);
        // styles on Runs
        foreach (Run run in body.Descendants<Run>()
          .Where(r => r.RunProperties != null && r.RunProperties.RunStyle != null))
          Console.WriteLine("Text: {0}->Run style: {1}", run.InnerText, run.RunProperties.RunStyle.Val );
      }
