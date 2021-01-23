     var pictureBoxes = this.Controls.OfType<PictureBox>().ToList();
     for (int i = 0; i < pictureBoxes.Count; i++) {
         pictureBoxes[i].DataBindings.Add("ImageLocation", 
                                          this.mainTableBindingSource, 
                                          "localPic" + (i + 1).ToString());
     }
