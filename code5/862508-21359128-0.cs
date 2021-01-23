    var files = Directory.GetFiles(originalPathFile)
                         .Select(nameWithExtension => Path.GetFileNameWithoutExtension(nameWithExtension))
                         .Where(name => { int number; return int.TryParse(name, out number); })
                         .Select(name => int.Parse(name))
                         .OrderBy(number => number).ToArray();
    
    while (files.Length > 1)
    {
    
        for (int j = 1; j < files.Length; j++)
        {
            Bitmap im1 = new Bitmap(originalPathFile + files[0].ToString() + ".png");
            Bitmap im2 = new Bitmap(originalPathFile + files[j].ToString() + ".png");
            if (compare(im1, im2))
            {
                File.Move(originalPathFile + files[j].ToString() + ".png", duplicatePath + files[j].ToString() + ".png");
                writer.WriteLine(files[j].ToString() + ".png" + " is a duplicate of " + files[0].ToString() + ".png");
            }
        }
        File.Move(originalPathFile + files[0].ToString() + ".png", movedOriginal + files[0].ToString() + ".png");
        writer.WriteLine(files[i].ToString() + ".png " + "has had its duplicates removed." );
        files = Directory.GetFiles(originalPathFile)
                         .Select(nameWithExtension => Path.GetFileNameWithoutExtension(nameWithExtension))
                         .Where(name => { int number; return int.TryParse(name, out number); })
                         .Select(name => int.Parse(name))
                         .OrderBy(number => number).ToArray();
    }
