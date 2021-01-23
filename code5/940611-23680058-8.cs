    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Map));
        Map testmap;
        using (XmlReader reader = XmlReader.Create("test.xml"))
        {
            testmap = (Map)ser.Deserialize(reader);
        }
        for (int y = 0; y < testmap.height; y += 1)
        {
            for (int x = 0; x < testmap.width; x += 1)
            {
                int t = int.Parse(testmap.data[y].Substring(x, 1));
                e.Graphics.DrawImage(Image.FromFile(testmap.tileset[t]), new Rectangle(x * 32, y * 32, 32, 32));
            }
        }
    }
