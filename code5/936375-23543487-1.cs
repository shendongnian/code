    // By popular suggestion, using Path.Combine...
    const string dstRootDirectoryName = @"C:\Musik";
    var destinationFileName = Path.Combine(dstRootDirectoryName, artist[i], songs[i]);
    if (File.Exists(destinationFileName)
    {
        File.Delete(destinationFileName);
    }
    else
    {
        File.Move(songs[i], destinationFileName);
        MessageBox.Show("The file:" + title[i] + " was moved");
    }
