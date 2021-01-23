    void Form1_Load(object sender, EventArgs e)
    {
        List<Image> images = new List<Image>();
    
        for (int i=1; i <= 16; i++)
            images.Add(Image.FromFile(String.Format(@"{0}\MGG{1}.png",Application.StartupPath,i);
        Random r = new Random();    
        A1.Image = images[r.Next(images.Count)];
    }
