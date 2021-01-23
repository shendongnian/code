    private void btnDrawImage_Click(object sender, EventArgs e)
        {
            string templateFile = Application.StartupPath + Path.DirectorySeparatorChar + "template_picture.jpg";
            //customerize your dispaly string style
            Font ft = new System.Drawing.Font("SimSun", 24);
            Brush brush = Brushes.Red;
            //start position(x,y)
            Point startPt = new Point(100, 100);
            //names from database
            var nameList = new List<string>(){
                "scott yang",
                "Vivi",
                "maxleaf",
                "lenka"};
            //process image on every name
            foreach (string name in nameList)
            {
                string msg = "Welcome " + name;
                Image templateImage = Image.FromFile(templateFile);
                Graphics g = Graphics.FromImage(templateImage);
                g.DrawString(msg, ft, brush, startPt.X, startPt.Y);
                g.Dispose();
                string savePath = "c:\\" + name + ".jpg";
                templateImage.Save(savePath);
            }
        }
