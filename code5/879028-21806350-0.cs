    PictureBox pb;
    
    main() {
      ...
      pb = new PictureBox();
      pb.ContextMenu = contextMenu_pictureBoxRightClick;
    }
    
    private void menuItem1_Click(object sender, EventArgs e) {
      // pb can be used directly here 
    }
