        void fixedPage_Loaded(object sender, RoutedEventArgs e)
        {
            var fixedDocument = sender as FixedPage;
            CalculateSize(fixedDocument);
        }
        private void CalculateSize(FixedPage fixedPage)
        {
            PrintQueue printQueue = LocalPrintServer.GetDefaultPrintQueue();
            PrintCapabilities capabilities = printQueue.GetPrintCapabilities();
            //get scale of the print wrt to screen of WPF visual
            double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / fixedPage.ActualWidth, capabilities.PageImageableArea.ExtentHeight / fixedPage.ActualHeight);
            //Transform the Visual to scale
            fixedPage.LayoutTransform = new ScaleTransform(scale, scale);
            //get the size of the printer page
            var sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
            //update the layout of the visual to the printer page size.
            fixedPage.Measure(sz);
            double x = capabilities.PageImageableArea.OriginWidth;
            double y = capabilities.PageImageableArea.OriginHeight;
            fixedPage.Arrange(new Rect(new Point(x, y), sz));
            fixedPage.UpdateLayout();
        }
