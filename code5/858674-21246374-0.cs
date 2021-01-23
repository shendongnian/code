    for (int i = 0; i < 10; i++)
    {
        if (button[i].BackColor == Color.GreenYellow) // if button colour is GreenYellow              
          {
             button[i].BackColor = Color.Beige;       // change to beige     
            
          }
    
          else if (button[i].BackColor == Color.Beige)  // if button is already beige
          {
             button[i + 1].BackColor = Color.Beige;   //skip current button and change next button to beige
             i++;
          }
    }
