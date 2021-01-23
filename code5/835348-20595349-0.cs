    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
    foreach(var item in listBox1.Items)
    {
        SaveFile.WriteLine(item.ToString());
    }
