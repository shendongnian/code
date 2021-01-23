    using (CookBookDataContext ctx = new CookBookDataContext(ResourceFile.DBConnection))
    {
        IEnumerable<RezeptBilder> bilder = 
                 from b in ctx.RezeptBilders where b.FKRezept == rezeptId select b;
        ImageList imageList = new ImageList();
        imageList.ColorDepth = ColorDepth.Depth24Bit;  // 
        imageList.ImageSize = yourImageSize;           //
        foreach(RezeptBilder b in bilder)
        {
            imageList.Images.Add(Helper.ByteArrayToImage(b.Bild.ToArray()));
        }
        return imageList;                
    }
