    List<Bitmap> images = new List<Bitmap>();
    private void CaptureScreen(){
       foreach(TabPage page in tabControlMain.TabPages){
          Bitmap bm = new Bitmap(page.Width, page.Height);
          tabControlMain.SelectedTab = page;
          page.DrawToBitmap(bm, page.ClientRectangle);
          images.Add(bm);
       }
    }
    //Then you can access the images of your TabPages in the list images
    //the index of TabPage is corresponding to its image index in the list images
