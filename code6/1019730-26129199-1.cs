     var rtf = File.ReadAllText(rtfFileName);
     var doc = new FlowDocument();
     var range = new TextRange(doc.ContentStart, doc.ContentEnd);
     using (var inputStream = new MemoryStream(Encoding.ASCII.GetBytes(rtf)))
     {
        range.Load(inputStream, DataFormats.Rtf);
        using (var outputStream = new FileStream(xamlFileName, FileMode.Create))
        {
           range.Save(outputStream, DataFormats.XamlPackage);
        }
     }
