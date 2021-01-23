      out of the loop:
      // old size of the parts:
      int ow = H.Width / 3;
      int oh = H.Height / 3;
      // new size of the parts:
      int nw = knight[0].Width / 3;
      int nh = knight[0].Height / 3;
          
      // inner loop:
      Rectangle rDest   = new Rectangle(0, 0, nw, nh);
      Rectangle rSource = new Rectangle(i * ow, j * oh, ow, oh);
      m.DrawImage(H, rDest, rSource , GraphicsUnit.Pixel);
