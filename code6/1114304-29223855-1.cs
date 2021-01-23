      protected void btnSaveInfo_Click(object sender, EventArgs e)
            {
                using (Bitmap img = GenerateQR("HelloWorld"))
                {
                    img.Save("QRCode.png"); //here gives me an error
                }
            }
    
      public Bitmap GenerateQR(string text)
            {
                var bw = new ZXing.BarcodeWriter();
                var encOptions = new ZXing.Common.EncodingOptions() { Width = 200, Height = 200, Margin = 0 };
                bw.Options = encOptions;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                return bw.Write(text); // already a bitmap...no need to copy (in fact copying might be part of your problem).
            }
