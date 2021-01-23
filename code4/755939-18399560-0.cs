    Code39BarcodeDraw barcode39 = BarcodeDrawFactory.Code39WithoutChecksum;
    System.Drawing.Image img = barcode39.Draw("Hello World", 40);
    
    Response.Clear();
    Response.Type = "image/png";
    img.Save(Response.OutputStream, Imaging.ImageFormat.Png);
    Response.Flush();
    Response.End();
