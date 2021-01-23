    var allFiles =Directory.EnumerateFiles("C:\\coneimages", "*.*", SearchOption.AllDirectories)
        .Where(s => s.EndsWith(".mp3") || s.EndsWith(".gif"));
    var coneFiles = allFiles
        .Where(f => Path.GetFileNameWithoutExtension(f).StartsWith("Cone_images", StringComparison.InvariantCultureIgnoreCase))
        .Select(f => new
        {
            File = f,
            NumberPart = String.Concat(Path.GetFileNameWithoutExtension(f).SkipWhile(char.IsLetter).TakeWhile(char.IsDigit))
        }).Where(x => x.NumberPart.Any())
        .Select(x => new { x.File, Number = int.Parse(x.NumberPart) })
        .OrderBy(x => x.Number);
    var pictureBoxFiles = allFiles
         .Where(f => Path.GetFileNameWithoutExtension(f).StartsWith("PictureBox_Images", StringComparison.InvariantCultureIgnoreCase))
        .Select(f => new
        {
            File = f,
            NumberPart = String.Concat(Path.GetFileNameWithoutExtension(f).SkipWhile(char.IsLetter).TakeWhile(char.IsDigit))
        }).Where(x => x.NumberPart.Any())
        .Select(x => new { x.File, Number = int.Parse(x.NumberPart) })
        .OrderBy(x => x.Number);
    var bothFileTypes = coneFiles.Zip(pictureBoxFiles, (cone, pic) => new { cone, pic });
    foreach (var xy in bothFileTypes)
    {
        Bitmap bmp1 = new Bitmap(xy.cone.File);
        Bitmap bmp2 = new Bitmap(xy.pic.File);
        Bitmap bmp3 = new Bitmap(GenerateImage(bmp2, bmp1));
        bmp3.Save(@"c:\coneimages\merged.bmp");
    }
