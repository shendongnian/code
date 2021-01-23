    var files = directory.GetFiles("*.csv", SearchOption.AllDirectories);
    using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
    {
        foreach (var file in files)
        {
            zip.AddFile(file.FullName);
        }
        zip.Save(Path.Combine(filePath, dirDate, "logs.zip"));
    }
    
    // Outside of using block
    foreach (var file in files)
    {
        File.Delete(file.FullName);
    }
