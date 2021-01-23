    if (listBox1.Items.Contains("game2.zip"))
    {
        if (File.Exists("\\Images\\game2.jpg"))
        {
            imageList1.Images.Add(Image.FromFile("\\Images\\game2.jpg"));
            listView1.Items.Add("", 1);
        }
    }
