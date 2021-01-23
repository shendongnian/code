             Bitmap bitmap = new Bitmap(@"D:\Project\QRCodes\myqrcode.png");
             try
            {               
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decodedData = result.Text;                
            }
            catch
            {
                throw new Exception("Cannot decode the QR code");
            }
