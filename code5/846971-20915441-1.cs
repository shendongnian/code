     private void button_KeyDown(object sender, KeyEventArgs e)
     {
        ((Control)sender).Controls.Add(helpBox);
        helpBox.KeyUp += button_KeyUp; //This will add KeyUp of our hosting button to hosted control, which means that said KeyUp handler can be raised by both helpBox and button
     }
     private void button_KeyUp(object sender, KeyEventArgs e)
     {
        ((Control)sender).Controls.Remove(helpBox);
        helpBox.KeyUp -= button1_KeyUp; // to avoid unnecessary calls event handler can be easily "subtracted" from helpBox
     }
