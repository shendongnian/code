    private void button5_Click(object sender, EventArgs e)
    {
        // switch to the second tabpage:
        tabControl1.SelectedIndex = 1;
         // i load all pictures from disk:
        string rootPath = "D:\\scrape\\sousers\\";
   
        // I use these hard coded pictures:
        List<List<string>> mapsParts = new List<List<string>>();
        mapsParts.Add(new List<string>()  
        { "dura.jpg", "SOU_HansP.png", "SOU_shiva.jpg", "SOU_Taw.jpg"} ) ;
        mapsParts.Add(new List<string>() 
        {"SOU_JonSkeet.jpeg", "SOU_geo.jpeg", "SOU_Antwina.jpg", "SOU_Enijar.png"} ) ;
        mapsParts.Add(new List<string>() 
        { "SOU_Ayna.jpg", "SOU_TAW2.jpg", "SOU_Lightness.jpg", "SOU_EricLippert.jpeg"} ) ;
        // i deduce the dimensions.. :
        int maxRow = mapsParts.Count;
        int maxCol = mapsParts[0].Count;
        // this is my screen dpi:
        int dpi = 96;
        // I deduce the size of one map part:
        Bitmap bmp = new Bitmap(rootPath + mapsParts[0][0]);
        int w = bmp.Width;
        int h = bmp.Height;
        bmp.Dispose();
        // now I know the total size of the map
        Bitmap bmpMap = new Bitmap(w * maxCol, h * maxRow);
        bmpMap.SetResolution(dpi, dpi); 
        // now I'll draw the parts onto the map:
        using (Graphics G = Graphics.FromImage(bmpMap) )
        for (int i = 0; i < maxRow; i++)
            for (int j = 0; j <maxCol; j++)
            {
               // read each part:
               bmp = new Bitmap(rootPath + mapsParts[i][j]);
               // make sure it has the same resolution:
               bmp.SetResolution(dpi, dpi);
               // draw it
               G.DrawImage(bmp, j * w, i * h);
               // clean up
               bmp.Dispose();
            }
        // done. We can show the map:
        pictureBox1.Image = bmpMap;
    }
