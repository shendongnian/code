      private int numTimes = 0;
      private void SimpleTest(object sender, RoutedEventArgs e)
      {
        if (numTimes == 0)
        {
          FlowDocument fd = new FlowDocument();
          Paragraph p = new Paragraph();
          p.Inlines.Add("This is the first bit of text.");
          fd.Blocks.Add(p);
          gRTbx.Document = fd;
          numTimes++;
        }
        else
        {
          FlowDocument fd = new FlowDocument();
          Paragraph p = new Paragraph();
          p.Inlines.Add("This is the second bit of text.");
          fd.Blocks.Add(p);
          gRTbx.Document = fd;
        }
      }
