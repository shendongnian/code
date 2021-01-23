    foreach (var file in dir.GetFiles())
    {
        var image = Image.FromFile(file.FullName);
        var item = new ListViewItem(file.Name)
        {
            Tag = file.Name;
        }
        listView1.Invoke(() => 
        {
            imageList1.Images.Add(file.Name, image);
            listView1.Items.Add(item);
        });
    }
