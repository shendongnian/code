    using (var inputImage = Tiff.Open(image, "r"))
    {
        width = inputImage.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
        height = inputImage.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
        inputImageData = new byte[width * height * bytePerPixel];
        var offset = 0;
        for (int i = 0; i < inputImage.NumberOfStrips(); i++)
        {
            offset += inputImage.ReadRawStrip(i, inputImageData, offset, (int)inputImage.RawStripSize(i));
        }
    }
