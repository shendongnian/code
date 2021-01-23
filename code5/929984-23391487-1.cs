           Bitmap bitMapIm = new
        System.Drawing.Bitmap(Server.MapPath(@"images\court.jpg"));
        Graphics graphicIm = Graphics.FromImage(bitMapIm);
        Pen penGreen = new Pen(Color.Green, 3);
        Pen penRed = new Pen(Color.Red, 3);
        for (int i = 0; i < GreenCircleX.Count; i++)
        {        
        graphicIm.DrawEllipse(penGreen, GreenCircleX[i] ,GreenCircleY[i], 7, 7);
            
        graphicIm.DrawString("X", new Font("Arial", 10, FontStyle.Bold), Brushes.Red, RedxX[i] ,RedxY[i]);
        }
        bitMapIm.Save(Server.MapPath(@"images\courtout.jpg"), ImageFormat.Jpeg);
        graphicIm.Dispose();
        bitMapIm.Dispose();
