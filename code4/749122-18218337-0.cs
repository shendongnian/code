    //SOME BYTES
    //Load here the DICOM image
    int width=640, height=480;
    int numberOfPixels = width*height;
    byte[] source = new byte[2*numberOfPixels];
    //With AFORGE
    var image = AForge.Imaging.UnmanagedImage.Create(width, height, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
    IntPtr ptrToImage = image.ImageData;
    //Copies the bytes from source to the image
    //System.Runtime.InteropServices
    Marshal.Copy(source, 0, ptrToImage,numberOfPixels);
    //WITH .NET
    System.Drawing.Bitmap bitmapImage = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
    var imageData = bitmapImage.LockBits(new System.Drawing.Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
    Marshal.Copy(source, 0, imageData.Scan0, numberOfPixels);
    bitmapImage.UnlockBits(imageData);   
