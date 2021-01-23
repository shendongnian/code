     var rtf = File.ReadAllText(rtfFileName);
     var doc = new FlowDocument();
     var range = new TextRange(doc.ContentStart, doc.ContentEnd);
     using (var inputStream = new MemoryStream(Encoding.ASCII.GetBytes(rtf)))
     {
        range.Load(inputStream, DataFormats.Rtf);
        using (var outputStream = new MemoryStream())
        {
           range.Save(outputStream, DataFormats.Xaml);
           outputStream.Position = 0;
           using (var xamlStream = new StreamReader(outputStream))
           {
              var xaml = xamlStream.ReadToEnd();
              File.WriteAllText(xamlFileName, xaml);
           }
        }
     }
