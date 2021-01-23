      // your creation loop..
      PictureBox pbox = new PictureBox();
      pbox.MouseMove += MouseScroll;           // <<--- hook into to the mousemove
      pan.MouseLeave += outSideCheck;          // <<--- hook into to the mouseleave
      // .. do your stuff.. here I put some paint on to test..
      pbox.BackColor = Color.FromArgb(255, 111, (i * 3) & 255, (i * 4) & 255);
      flowLayoutPanel1.Controls.Add(pbox);
