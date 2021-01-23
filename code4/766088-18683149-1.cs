    List<string> files = new List<string> { "game1.zip", "game2.zip" };
    var index = 0;
    foreach (var file in files)
    {
        if (File.Exists("\\Images\\" + file))
        {
            imageList1.Images.Add(Image.FromFile("\\Images\\" + file.Replace(".zip", ".jpg")));
            listView1.Items.Add("", index);
            index++;
        }
    }
