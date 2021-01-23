      public void Receive() {
             BitmapTransmission bt = bt.Receive(m_stream);
             // check for exceptions maybe?
             pictureBox1.Image = bt.Bitmap;
      }
