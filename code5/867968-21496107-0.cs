    Bitmap BWImage = new Bitmap(fileName);
    // Lock destination bitmap in memory
    System.Drawing.Imaging.BitmapData BWLockImage = BWImage.LockBits(new Rectangle(0, 0, BWImage.Width, BWImage.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
     
    // Copy image data to binary array
    int imageSize = BWLockImage.Stride * BWLockImage.Height;
    byte[] BWImageBuffer = new byte[imageSize];
    Marshal.Copy(BWLockImage.Scan0, BWImageBuffer, 0, imageSize);
    DoOCR(BWLockImage, BWImageBuffer, tmpPosRect, false);
     
    
     
    // Do the OCR with this function
    public string DoOCR(System.Drawing.Imaging.BitmapData BWLockImage, byte[] BWImageBuffer, Rectangle iAusschnitt, bool isNumber)
    {
        Bitmap tmpImage = Bildausschnitt1bpp(BWLockImage, BWImageBuffer, iAusschnitt);
        string file = Path.GetTempFileName();
        string tmpResult = "";
        try
        {
            tmpImage.Save(file, ImageFormat.Tiff);
            _MODIDocument.Create(file);
            // Modi parameter erstellen
            _MODIDocument.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, false, false);
     
            MODI.IImage myImage = (MODI.IImage)_MODIDocument.Images[0]; //first page in file
            MODI.ILayout myLayout = (MODI.ILayout)myImage.Layout;
            tmpResult = myLayout.Text;
        }
        catch
        {
            if (_MODIDocument != null)
            {
                _MODIDocument.Close(false); //Closes the document and deallocates the memory.
                _MODIDocument = null;
            }
            // Bild freigeben
            tmpImage.Dispose();
            tmpImage = null;
            // Garbage Collector ausführen
            GC.Collect();
            // Bilddatei löschen
            File.Delete(file);
        }
        return tmpResult;
    }
