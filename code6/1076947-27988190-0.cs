    IBarcodeWriter writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = 300,
                        Width = 300
                    }
                };
    var result = writer.Write("generator works");
    var wb = result.ToBitmap() as WriteableBitmap;
    
    //add to image component
    image.Source = wb;
