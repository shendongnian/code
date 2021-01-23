     PrintQueue selectedPrntQueue = printDialog.PrintQueue;     
     XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(selectedPrntQueue);
     SerializerWriterCollator collator = writer.CreateVisualsCollator();
     collator.BeginBatchWrite();
     var paginator = FixedDocument.DocumentPaginator;
     FixedPage fixedPage = paginator.GetFixedPage(printedPageCount)
     ContainerVisual newPage = new ContainerVisual();
     Size sz = new Size(pageSize.Height.Value, pageSize.Width.Value);
     fixedPage.Measure(sz);
     fixedPage.Arrange(new Rect(new Point(), sz));
     fixedPage.UpdateLayout();
     newPage.Children.Add(fixedPage);
     collator.Write(newPage);
