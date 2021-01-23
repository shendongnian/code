    Control focusedCtrl;
    //Enter event handler for all your TextBoxes
    private void TextBoxesEnter(object sender, EventArgs e){
        focusedCtrl = sender as TextBox;
    }
    //Click event handler for your btnNum1
    private void btnNum1_Click(object sender, EventArgs e)
    {
      if (focusedCtrl != null){
        focusedCtrl.Focus();
        SendKeys.Send("1");
      }
    }
