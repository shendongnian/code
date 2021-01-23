    PopupForm popup = new PopupForm();
    popup.Owner = mainForm;//or this if the code is placed in the MainForm class
    //MouseUp event handler for your mainForm
    private void mainForm_MouseUp(object sender, MouseEventArgs e){
      if(e.Button == MouseButtons.Right){
        popup.Location = PointToScreen(e.Location);
        if(!popup.Visible) popup.Visible = true;
      } else if(popup.Visible) {
        popup.Hide();//Don't close, just hide, otherwise you have to handle more...
      }
    }
    
