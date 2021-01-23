    WriteableBitmap eb = new WriteableBitmap(bitmapImage);
    MemoryStream memoryStream1 = new MemoryStream();
    eb.SaveJpeg(memoryStream1, bitmapImage.PixelWidth, bitmapImage.PixelHeight, 0, 100);
    memoryStream1.Seek(0, SeekOrigin.Begin);
    MediaLibrary library1 = new MediaLibrary();
    string filename1 = "SavedPicture_" + DateTime.Now.ToString("y_M_d_H_m_s");
    Picture pic1 = library1.SavePicture(filename1, memoryStream1);
