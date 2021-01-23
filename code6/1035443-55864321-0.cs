    ImageList largeImageList = new ImageList();
    largeImageList.ColorDepth = ColorDepth.Depth32Bit;
    largeImageList.ImageSize = new Size(64, 64); //actual size of image
    largeImageList.Images.Add(Properties.Resources.psd64);
    
    ListView listView = new ListView();
    listView.LargeImageList=largeImageList;
