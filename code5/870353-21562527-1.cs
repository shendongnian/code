    //Place it in the directory of your application
    string mp4Path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "mp4File.mp4");
    //check if it hasn't been written to disk yet
    if (!File.Exists(mp4Path))
    {
        //write it to disk
        File.WriteAllBytes(mp4Path, namespace.properties.resources.file.mp4);
    }
    //play using mp4Path
