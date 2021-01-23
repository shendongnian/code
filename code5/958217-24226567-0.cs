    private void button1_Click(object sender, EventArgs e)
    {
            
      Task.Factory.StartNew(() => LoadPics());
      // if TPL not available
      // use Action delegate
      // Not showing endinvoke here
      // var action = new Action(LoadPics);
      // action.BeginInvoke(null, null);
    }
    
    private void SetImage(Image img)
    {
        pictureBox1.Image = img;
        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
    }
    
    private void LoadPics()
    {       
       for ( int i = 0; i < filePaths.Length; i++ )
       {
            // Invoke UI thread for changing picture
            pictureBox1.Invoke(new Action(() => SetImage(imList.Images[i])));
            Thread.Sleep(1000);
       }
    }
