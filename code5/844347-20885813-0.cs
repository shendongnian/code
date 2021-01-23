      public static void AddBlock(Block from, FlowDocument to)
      {
        if (from != null)
        {
            TextRange range = new TextRange(from.ContentStart, from.ContentEnd);
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            System.Windows.Markup.XamlWriter.Save(range, stream);
            range.Save(stream, DataFormats.XamlPackage);
            TextRange textRange2 = new TextRange(to.ContentEnd, to.ContentEnd);
            textRange2.Load(stream, DataFormats.XamlPackage);
        }
    }
