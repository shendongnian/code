    void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        bitmap = (Bitmap)eventArgs.Frame.Clone();
        pictureBox1.Image = bitmap;
             try
             {
                 this.Invoke((MethodInvoker)delegate
                 {
                     //saves image on its thread
                     pictureBox1.Image.Save("c:\\image\\image1.jpg");
                 });
             }
             catch (Exception ex)
             {
                 MessageBox.Show(""+ex);
             }
     }
