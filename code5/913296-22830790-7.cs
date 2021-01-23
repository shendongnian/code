    private void Form1_Load(object sender, EventArgs e)
    {
        this.cbSange.DisplayMember = "Name";
        var path = @"C:\Programmer\Jukebox\Songs";
        var files = System.IO.Directory.GetFiles(path);
		
        foreach(var file in files)
        {
            var item = new AudioItem
            {
                Name = System.IO.Path.GetFileNameWithoutExtension(file),
                Path = file
            };
            this.cbSange.Items.Add(item);
        }
    }
