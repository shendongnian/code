    /// <summary>
    /// created by Henka Programmer.
    /// Class to make the converting images formats and data structs so easy.
    /// This Class supporte the following types:
    /// - BtimapImage, 
    /// - Stream,
    /// - ByteImage
    /// 
    /// and the other option is image resizing.
    /// </summary>
    public class Photo
    {
    public BitmapImage BitmapImage;
    public System.IO.Stream Stream;
    public byte[] ByteImage;
    public Photo(Uri PhotoUri)
    {
        this.BitmapImage = new BitmapImage(PhotoUri);
        this.Stream = new MemoryStream();
        this.Stream = this.BitmapImage.StreamSource;
        this.ByteImage = StreamToByteArray(this.Stream);
    }
    public Photo(Bitmap Photo_Bitmap)
        : this((ImageSource)(new ImageSourceConverter().ConvertFrom(Photo_Bitmap)))
    {
        /*
        ImageSourceConverter c = new ImageSourceConverter();
        byte[] bytes = (byte[])TypeDescriptor.GetConverter(Photo_Bitmap).ConvertTo(Photo_Bitmap, typeof(byte[]));
        Photo ph = new Photo(bytes);*/
    }
    public Photo(ImageSource PhotoSource) : this(PhotoSource as BitmapImage) { }
    public Photo(BitmapImage BitmapPhoto)
    {
        this.BitmapImage = BitmapPhoto;
        this.ByteImage = GetByteArrayFromImageControl(BitmapPhoto);
        this.Stream = new MemoryStream();
        WriteToStream(this.Stream, this.ByteImage);
    }
    public Photo(string path)
    {
        try
        {
            this.Stream = System.IO.File.Open(path, System.IO.FileMode.Open);
            this.BitmapImage = new BitmapImage();
            BitmapImage.BeginInit();
            BitmapImage.StreamSource = Stream;
            BitmapImage.EndInit();
            this.ByteImage = StreamToByteArray(this.Stream);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }
    public Photo(byte[] byteimage)
    {
        this.ByteImage = new byte[byteimage.Length];
        this.ByteImage = byteimage;
        // WriteToStream(this.Stream, this.ByteImage);
        //MemoryStream ms = new MemoryStream(byteimage);
        this.Stream = new MemoryStream(byteimage);
    }
    private void WriteToStream(Stream s, Byte[] bytes)
    {
        using (var writer = new BinaryWriter(s))
        {
            writer.Write(bytes);
        }
    }
    private byte[] StreamToByteArray(Stream inputStream)
    {
        if (!inputStream.CanRead)
        {
            throw new ArgumentException();
        }
        // This is optional
        if (inputStream.CanSeek)
        {
            inputStream.Seek(0, SeekOrigin.Begin);
        }
        byte[] output = new byte[inputStream.Length];
        int bytesRead = inputStream.Read(output, 0, output.Length);
        Debug.Assert(bytesRead == output.Length, "Bytes read from stream matches stream length");
        return output;
    }
    private BitmapImage BitmapImageFromBytes(byte[] bytes)
    {
        BitmapImage image = new BitmapImage();
        using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
        {
            imageStream.Write(ByteImage, 0, ByteImage.Length);
            imageStream.Seek(0, System.IO.SeekOrigin.Begin);
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = imageStream;
            image.EndInit();
            //image.Freeze();
            
        }
        return image;
    }
    public BitmapImage GetResizedBitmap(int width, int height)
    {
        ImageSource imgSrc = CreateResizedImage(this.ByteImage, width, height);
        return new Photo(GetEncodedImageData(imgSrc, ".jpg")).BitmapImage;
    }
    private ImageSource CreateResizedImage(byte[] imageData, int width, int height)
    {
        BitmapImage bmpImage = new BitmapImage();
        bmpImage.BeginInit();
        if (width > 0)
        {
            bmpImage.DecodePixelWidth = width;
        }
        if (height > 0)
        {
            bmpImage.DecodePixelHeight = height;
        }
        bmpImage.StreamSource = new MemoryStream(imageData);
        bmpImage.CreateOptions = BitmapCreateOptions.None;
        bmpImage.CacheOption = BitmapCacheOption.OnLoad;
        bmpImage.EndInit();
        Rect rect = new Rect(0, 0, width, height);
        DrawingVisual drawingVisual = new DrawingVisual();
        using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        {
            drawingContext.DrawImage(bmpImage, rect);
        }
        RenderTargetBitmap resizedImage = new RenderTargetBitmap(
        (int)rect.Width, (int)rect.Height, // Resized dimensions
        96, 96, // Default DPI values
        PixelFormats.Default); // Default pixel format
        resizedImage.Render(drawingVisual);
        return resizedImage;
    }
    internal byte[] GetEncodedImageData(ImageSource image, string preferredFormat)
    {
        byte[] returnData = null;
        BitmapEncoder encoder = null;
        switch (preferredFormat.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                encoder = new JpegBitmapEncoder();
                break;
            case ".bmp":
                encoder = new BmpBitmapEncoder();
                break;
            case ".png":
                encoder = new PngBitmapEncoder();
                break;
            case ".tif":
            case ".tiff":
                encoder = new TiffBitmapEncoder();
                break;
            case ".gif":
                encoder = new GifBitmapEncoder();
                break;
            case ".wmp":
                encoder = new WmpBitmapEncoder();
                break;
        }
        if (image is BitmapSource)
        {
            MemoryStream stream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            encoder.Save(stream);
            stream.Seek(0, SeekOrigin.Begin);
            returnData = new byte[stream.Length];
            BinaryReader br = new BinaryReader(stream);
            br.Read(returnData, 0, (int)stream.Length);
            br.Close();
            stream.Close();
        }
        return returnData;
    }
    public byte[] GetByteArrayFromImageControl(BitmapImage imageC)
    {
        MemoryStream memStream = new MemoryStream();
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(imageC));
        encoder.Save(memStream);
        return memStream.GetBuffer();
    }
    public ImageSource ToImageSource()
    {
        ImageSource imgSrc = this.BitmapImage as ImageSource;
        return imgSrc;
    }
    public System.Windows.Controls.Image ToImage()
    {
        System.Windows.Controls.Image Img = new System.Windows.Controls.Image();
        Img.Source = this.ToImageSource();
        return Img;
    }
    }
