    <StackPanel>
        <Image x:Name="myImage" Stretch="None" Source="Assets/bling.png"/>
        <Slider x:Name="mySilder" ValueChanged="mySilder_ValueChanged"></Slider>
    </StackPanel>
----------
    // namespaces
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.Storage;
    // our copy of the image
    WriteableBitmap copy;
    
    public MainPage()
    {
        this.InitializeComponent();
    }
    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        // storage file for the image (load it)
        StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/bling.png"));
        // create a bitmap image
        BitmapImage bi = new BitmapImage();
        using (
            // Open a stream for the selected file.
        Windows.Storage.Streams.IRandomAccessStream fileStream =
            await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
        {
            // load the image into the BitmapImage
            await bi.SetSourceAsync(fileStream);
            // create a copy of the image            
            copy = new WriteableBitmap(bi.PixelWidth, bi.PixelHeight);
            // load the image into writeablebitmap copy
            fileStream.Seek(0);
            await copy.SetSourceAsync(fileStream);
        }
    }
    private WriteableBitmap ChangeBrightness(WriteableBitmap source, byte change_value)
    {
        WriteableBitmap dest = new WriteableBitmap(source.PixelWidth, source.PixelHeight);        
        byte[] color = new byte[4];
        using (Stream s = source.PixelBuffer.AsStream())
        {
            using (Stream d = dest.PixelBuffer.AsStream())
            {
                // read the pixel color
                while (s.Read(color, 0, 4) > 0)
                {
                    // color[0] = b
                    // color[1] = g 
                    // color[2] = r
                    // color[3] = a
                    // do the adding algo per byte (skip the alpha)
                    for (int i = 0; i < 4; i++)
                    {
                        if ((int)color[i] + change_value > 255) color[i] = 255; else color[i] = (byte)(color[i] + change_value);
                    }
                    // write the new pixel color
                    d.Write(color, 0, 4);                        
                }
            }
        }
        
        // return the new bitmap
        return dest;
    }
    private void mySilder_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        if (this.mySilder != null)
        {
            // deterime the brightness to add
            byte value_to_add = (byte)((this.mySilder.Value / this.mySilder.Maximum) * 255);
            // get the new bitmap with the new brightness
            WriteableBitmap ret = ChangeBrightness(copy, value_to_add);
            // set it as the source so we can see the change
            this.myImage.Source = ret;
        }
    }
