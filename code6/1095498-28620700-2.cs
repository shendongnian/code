      private int numTimes = 0;
      private FlowDocument fd = new FlowDocument();
      private Paragraph p = new Paragraph();
      private void SimpleTest(object sender, RoutedEventArgs e)
      {
        if (numTimes == 0)
        {
          p.Inlines.Add("This is the first bit of text.");
          fd.Blocks.Add(p);
          gRTbx.Document = fd;
          numTimes++;
        }
        else
        {
          p.Inlines.Clear();
          fd.Blocks.Clear();
          p.Inlines.Add("This is the second bit of text.");
          fd.Blocks.Add(p);
          gRTbx.Document = fd;
        }
      }
