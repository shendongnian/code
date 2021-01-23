    foreach (var file in new DirectoryInfo(@"C:\Source\").GetFiles())
    {
          using (var image = Image.FromFile(file.FullName))
          {
                using (var newImage = ScaleImage(image, 150, 150))
                {
                      var newImageName = Path.Combine(@"C:\Dest\", Path.GetFileNameWithoutExtension(file.Name) + "_resized" + file.Extension);
                      newImage.Save(newImageName, ImageFormat.Png);
                }
          }
    }
