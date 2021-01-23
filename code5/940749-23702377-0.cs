    public static XElement ImageToXElement(System.Drawing.Image image)
    {
        Bitmap bitmap = new Bitmap(image);
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
        return new XElement("Image",
            new XAttribute("PixelData",
                Convert.ToBase64String(
                    (byte[])converter.ConvertTo(bmp, typeof(byte[]))));
    }
