     private void button1_Click(object sender, EventArgs e)
            {
                
                int whiteColor = 0;
                int blackColor = 0; 
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color color = bmp.GetPixel(x, y); 
                        
                        if (color.ToArgb()==Color.White.ToArgb())
                        {
                            whiteColor++;  
                        }
    
                        else
                            if (color.ToArgb() == Color.White.ToArgb())
                            {
                                blackColor++; 
                            }
                    }
    
                }
            }
