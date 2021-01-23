    void printDoc()
    {
        PrintDocument document = new PrintDocument();
        BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
        Image barcodeImage = bdraw.Draw("PO7120172733039800", 50);
            
        document.PrintPage += delegate(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(barcodeImage, 0, 0);
            e.Graphics.DrawString("PO7120172733039800", new Font("arial", 8), new SolidBrush(Color.Black),0,50);
        };
        document.Print();
    }
