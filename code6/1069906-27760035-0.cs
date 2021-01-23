            Bitmap bmp = new Bitmap(300, 50);
            Graphics gfx = Graphics.FromImage(bmp);
            
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            gfx.DrawString("Why I have black outer pixels?", new Font("Verdana", 14),
                new SolidBrush(Color.White), 0, 0);
            gfx.Dispose();
            bmp.Save(Application.StartupPath + "\\test.png", ImageFormat.Png);
