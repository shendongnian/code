      // old size of the parts
      int ow = I.Width / 3;
      int oh = I.Height / 3;
      // new size of the parts
      int nw = i * (knight[index].Width / 3;
      int nh = i * (knight[index].Height / 3;
          
      Rectangle rDest   = new Rectangle(0, 0, nw, nh);
      Rectangle rSource = new Rectangle(i * ow, j * oh, ow, oh);
      m.DrawImage(H, rDest, rSource , GraphicsUnit.Pixel);
