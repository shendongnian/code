      private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
      {
         PictureBox pb = new System.Windows.Forms.PictureBox();
         pb.Location = new System.Drawing.Point(319, 32);// THE LOCATION AND CONTEXT IS UP TO YOU
         pb.Name = "pictureBox1";
         pb.Size = new System.Drawing.Size(100, 50);
         pb.TabIndex = 7;
         pb.TabStop = false;
         pb.MouseClick += new System.Windows.Forms.MouseEventHandler
      }
