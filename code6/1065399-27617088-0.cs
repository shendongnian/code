    Excel.Picture pic = (Excel.Picture)CurSheet.Pictures(1);
    pic.Copy();
    IDataObject data = Clipboard.GetDataObject();
    Image pic2 = (Image)data.GetData(DataFormats.Bitmap, true);
    pic2.Save("pic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
