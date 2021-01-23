    private async Task FlowDoc2Image(
        FlowDocument document, DataClass dataContext, Stream imageStream)
    {
        var flowDocumentScrollViewer = new FlowDocumentScrollViewer
        {
            VerticalScrollBarVisibility = ScrollBarVisibility.Hidden,
            HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
            Document = document,
            DataContext = dataContext,
        };
        flowDocumentScrollViewer.Measure(
            new Size(double.PositiveInfinity, double.PositiveInfinity));
        flowDocumentScrollViewer.Arrange(new Rect(flowDocumentScrollViewer.DesiredSize));
        await Task.Delay(100);
        var renderTargetBitmap = new RenderTargetBitmap(
            (int)flowDocumentScrollViewer.DesiredSize.Width,
            (int)flowDocumentScrollViewer.DesiredSize.Height,
            96, 96, PixelFormats.Default);
        renderTargetBitmap.Render(flowDocumentScrollViewer);
        var pngEncoder = new PngBitmapEncoder { Interlace = PngInterlaceOption.On };
        pngEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
        pngEncoder.Save(imageStream);
    }
