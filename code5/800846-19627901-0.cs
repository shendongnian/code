    using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
    {
        foreach (var file in directory.GetFiles("*.csv", SearchOption.AllDirectories))
        {
            zip.AddFile(file.FullName);
        }
        zip.Save(filePath + "\\" + dirDate + "\\"+"logs.zip");
    }
    
    // Outside of using block
    foreach (var file in directory.GetFiles("*.csv", SearchOption.AllDirectories))
    {
        File.Delete(file.FullName);
    }
