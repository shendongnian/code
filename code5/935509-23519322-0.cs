    void pictureBox_DragDrop(object sender, DragEventArgs e) {
      PictureBox pb = e.Data.GetData(typeof(PictureBox)) as PictureBox;
      if (pb != null) {
        ((PictureBox)sender).Image = pb.Image;
        pb.Image = null;
      }
    }
