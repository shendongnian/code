     protected void Button2_Click1(object sender, EventArgs e)
        {
           
             string path = Server.MapPath(Image1.ImageUrl);
             string newpath =Server.MapPath(@"~/filename.png");
    
            ////create an image object from the image in that path
            System.Drawing.Bitmap img =new  System.Drawing.Bitmap(path);      
           
            Bitmap map = RotateBitmap(COnvert.ToSingle(textBox1.Text), img);
            map.Save(newpath);
           
            
         
           
            ////release image file
            img.Dispose();
        }
         public Bitmap RotateBitmap(float Angle, Bitmap bm_in)
        {
            try
            {
                float wid = bm_in.Width;
                float hgt = bm_in.Height;
                Point[] corners = { new Point(0, 0), new Point(int.Parse(wid.ToString()), 0), new Point(0, int.Parse(hgt.ToString())), new Point(int.Parse(wid.ToString()), int.Parse(hgt.ToString())) };
                int cx = int.Parse(wid.ToString()) / 2;
                int cy = int.Parse(hgt.ToString()) / 2;
                long i;
                for (i = 0; i <= 3; i++)
                {
                    corners[i].X -= Convert.ToInt32(cx.ToString());
                    corners[i].Y -= Convert.ToInt32(cy.ToString());
                }
    
    
                float theta = (float)(Angle * Math.PI / 180.0);
                float sin_theta = (float)Math.Sin(theta);
                float cos_theta = (float)Math.Cos(theta);
                float X;
                float Y;
                for (i = 0; i <= 3; i++)
                {
                    X = corners[i].X;
                    Y = corners[i].Y;
                    corners[i].X = (int)(X * cos_theta + Y * sin_theta);
                    corners[i].Y = (int)(-X * sin_theta + Y * cos_theta);
                }
    
    
                float xmin = corners[0].X;
                float ymin = corners[0].Y;
                for (i = 1; i <= 3; i++)
                {
                    if (xmin > corners[i].X)
                        xmin = corners[i].X;
                    if (ymin > corners[i].Y)
                        ymin = corners[i].Y;
                }
                for (i = 0; i <= 3; i++)
                {
                    corners[i].X -= int.Parse(xmin.ToString());
                    corners[i].Y -= int.Parse(ymin.ToString());
                }
    
    
                Bitmap bm_out = new Bitmap((int)(-2 * xmin), (int)(-2 * ymin));
                Graphics gr_out = Graphics.FromImage(bm_out);
                // ERROR: Not supported in C#: ReDimStatement
                Point[] temp = new Point[3];
                if (corners != null)
                {
                    Array.Copy(corners, temp, Math.Min(corners.Length, temp.Length));
                }
                corners = temp;
                gr_out.DrawImage(bm_in, corners);
                return bm_out;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return bm_in;
            }
        }
