    foreach (string item in listBox1.Items)
    {
        if (File.Exists(item))
        {
            FileInfo file = new FileInfo(item);
            listBox2.Items.Add(DecToHex(file.Length));
        }
    }
