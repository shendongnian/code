    protected void Button1_Click(object sender, EventArgs e)
    {
        DirectoryInfo dinfo = new DirectoryInfo(@"D:\Local_temp");
        FileInfo[] files = dinfo.GetFiles("*.msg");
        DateTime dt;
        if (DateTime.TryParse(this.TextBox1.Text, out dt))
        {
            files.Where(x => File.GetCreationTime(x.FullName).Date == dt.Date).ToList().ForEach(x => this.ListBox1.Items.Add(x.Name));
        }
    }
