    using ImageMagick;
    using (var sourceImage = new MagickImage(texture)){ //texture is of type Stream
        sourceImage.Resize(desiredWidth, desiredHeight);
        sourceImage.Write(memoryStream, MagickFormat.Png);
    }
    // use memoryStream here
