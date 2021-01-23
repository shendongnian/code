    bool keyDown;
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if(keyIsDown[e.KeyCode]) return;
        switch(e.KeyCode){
          case Keys.D1:
               Beat1.Image = Beatpadpc.Properties.Resources.white_square_button;
               break;
          case Keys.D2:
               Beat2.Image = Beatpadpc.Properties.Resources.white_square_button;
               break;
        }
        keyIsDown[e.KeyCode] = true;
    }
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {        
        switch(e.KeyCode){
          case Keys.D1:
               Beat1.Image = Beatpadpc.Properties.Resources.black_square_button;
               break;
          case Keys.D2:
               Beat2.Image = Beatpadpc.Properties.Resources.black_square_button;
               break;
        }
        keyIsDown[e.KeyCode] = false;
    }
