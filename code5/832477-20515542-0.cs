    Bitmap bmp;
    
    if (!pictures.TryGetValue(name, out bmp))
    {
        bmp = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("MyProject.Resources." + name + ".png"));
        pictures.Add(name, bmp);
    }
    return bmp;
