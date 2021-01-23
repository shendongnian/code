    using (ShellFile mediafile = ShellFile.FromFilePath(mediaEntry.FilePath))
    {
        ShellPropertyWriter pw = mediafile.Properties.GetPropertyWriter();
        pw.WriteProperty(SystemProperties.System.Music.Artist, mediaEntry.Actor);
        pw.WriteProperty(SystemProperties.System.Music.Genre, mediaEntry.Genre);
        pw.WriteProperty(SystemProperties.System.Rating, mediaEntry.Rating);
        pw.Close();
    }
