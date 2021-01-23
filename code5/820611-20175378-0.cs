    using (var file = new System.IO.StreamReader("testfile.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            listBox1.Items.Add(line);
        }
    }
