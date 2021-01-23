    string path = "D:\\OP_Display";
    string[] files = System.IO.Directory.GetFiles(path);
    for (int i = 0; i < files.Length; i++)
    {
        listBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(files[i]));
    }
