    // ...
    do
    {
        string currentRead = reader.ReadLine();
        if (!string.IsNullOrWhiteSpace(currentRead)) // ignore empty lines
        {
            playlist.Add(currentRead);
           listBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(currentRead));
        }
    } while (true);
