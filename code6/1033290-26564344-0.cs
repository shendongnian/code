    public void PrintThemAll()
    {
        var document = new PrintDocument();
        document.PrintPage += document_PrintPage;
        document.Print();
    }
    void document_PrintPage(object sender, PrintPageEventArgs e)
    {
        var graphics = e.Graphics;
        var normalFont = new Font("Calibri", 14); 
        var pageBounds = e.MarginBounds;
        var drawingPoint = new PointF(pageBounds.Left, (pageBounds.Top + normalFont.Height));
        graphics.DrawString("Name: Paul", normalFont, Brushes.Black, drawingPoint);
          
        drawingPoint.Y += normalFont.Height;
        graphics.DrawString("Bought: bike", normalFont, Brushes.Black, drawingPoint);
        e.HasMorePages = false; // No pages after this page.
    }
