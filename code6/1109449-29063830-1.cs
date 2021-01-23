    string[] files;
    void loadImages() 
    {
        files = string[] files = Directory.GetFiles(Server.MapPath("~/images/"));
        for (int i = 0; i < files.Length; i++)
        {
            listBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(files[i]));
        }
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
    }
    void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(files[listBox1.SelectedIndex]);
        }
