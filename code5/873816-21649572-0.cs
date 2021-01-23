    private void Picturemethod(object sender, MouseEventArgs e)
    {
       var pBox = sender as PictureBox;
       if(pBox != null) 
       {
          pBox.Visible = false;
       }
    }
