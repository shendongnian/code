    List<ImageInfo> images = new List<ImageInfo>();
    Image image = Image.FromFile(@"C:\myphoto.png");
    images.Add(new ImageInfo(image, "this is a description"));
    ...
    pictureBox1.Image = images[0].Image;
