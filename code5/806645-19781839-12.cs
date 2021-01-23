    foreach (string JPEGImages in Directory.GetFiles(GivenFolder, "*.jpg"))
    {
        //Add the Image gathered to the List collection
        Image img = System.Drawing.Image.FromFile(JPEGImages);
        img.Tag = JPEGImages;
        ImagesInFolder.Add(img);
    }
