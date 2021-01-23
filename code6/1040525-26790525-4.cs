    var files = new DirectoryInfo(@"C:\Source\")
                .GetFiles()
                .Where(f => f.IsImage());
    foreach (var file in files)
    {
          using (var image = Image.FromFile(file.FullName))
          {
                using (var newImage = ScaleImage(image, 150, 150))
                {
                    try
                    {
                        var newImageName = Path.Combine(@"C:\Dest\", Path.GetFileNameWithoutExtension(file.Name) + "_resized" + file.Extension);
                        newImage.Save(newImageName, ImageFormat.Jpeg);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
    }
    public static class Extensions
    {
        public static bool IsImage(this FileInfo file)
        {
            var allowedExtensions = new[] {".jpg", ".png", ".gif", ".jpeg"};
            return allowedExtensions.Contains(file.Extension.ToLower());
        }
    }
