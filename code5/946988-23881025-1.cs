     void newButton_Click(object sender, EventArgs e)
     {
           Button newButton = sender as Button;
           int buttonText = Convert.ToInt32( newButton.Text);
              foreach(Control c flowLayoutPanel1.Controls)
              {
                  if (c is Button)
                  {
                     Button newBtn = (Button)c;
                     int _val = Convert.ToInt32(newBtn.Text);
                      if(_val > buttonText)
                      {
                       if(_val % 2 == 0)
                         newBtn.BackColor = Color.Green;
                       else
                         newBtn.BackColor=Color.Red;
                      }
                 }
              }
       }
