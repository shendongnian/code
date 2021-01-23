    var images = new List<Bitmap>();
    var files = Directory.GetFiles(path);
    for (int i = 0; i < files.Count(); i++)
    {
        string nextimage = files[i];
        Bitmap bmp1 = Bitmap.FromFile(nextimage) as Bitmap
        images.Add(bmp1); //to keep images in RAM for later process
        bmp1.Save(somePath + "\\bmp" + i.ToString()); // to save images on disc
    }
