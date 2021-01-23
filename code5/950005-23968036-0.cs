           if (bmp.GetPixel(k, i).R < 10  && bmp.GetPixel(k + 1, i).R > 200)
           {
             x2 = k;
             bmp.SetPixel(k, i, Color.Red);
             goto loop1;
           }
         }
       }
     }
           
    }
    loop1:
    pictureBox1.Image = bmp;
    MessageBox.Show("(" + x2 + ")")
