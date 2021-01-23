    private void button1_Click(object sender, EventArgs e)
    {
        List<Image> Images1 = new List<Image>();
        ResourceManager rm = new ResourceManager("ResourceReader.MyResource", Assembly.GetExecutingAssembly());
        string index1 = textBox1.Text;
        pictureBox1.Image = rm.GetObject(index1) as Image;
        Images1.Add((Image)Booster_pack_2.Properties.Resources.ResourceManager.GetObject(index1));
    }
