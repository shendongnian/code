     public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    
    byte[] trytry = ImageToByte(bitmap);
                    memoryStream.Write(trytry,0,trytry.Length );
                    base.Response.ClearContent();
                    base.Response.ContentType = "image/Gif";
                    base.Response.BinaryWrite(memoryStream.ToArray());
