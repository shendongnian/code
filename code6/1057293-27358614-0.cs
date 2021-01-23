    // Generate QR-Code and encode barcode to gif format
    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Gif;
    qrcode.drawBarcode("C:\\qrcode.gif"); 
    /*
    You can also call other drawing methods to generate barcodes          
    public void drawBarcode(Graphics graphics);
    public void drawBarcode(string filename);    
    public Bitmap drawBarcode();
    public void drawBarcode(Stream stream);             
    */
