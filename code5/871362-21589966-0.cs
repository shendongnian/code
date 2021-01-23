    void Ps_Sample_Apl_CS_ShowSilhouette(MemoryStream buff)
    {
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = buff;
        bitmapImage.EndInit();
        ImagePic.Source = bitmapImage;
    }
