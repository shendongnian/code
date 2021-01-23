    {
    // Adding first genre title
    string[] lines = File.ReadAllLines(@"C:\Users\James Dunn\Documents\Visual Studio 2012\Projects\Assignment 2\Assignment 2\MyJukeBox\bin\Debug\Media\Genre.txt");
    for (int l = 3; l < lines.Length; l++)
    {
    mediaLibrary[0].Items.Add(lines[l]);
    if (l == 4)
    break;
    }
    genreTitleTextBox.(mediaLibrary[0]);
    }
