     void newButton_Click(object sender, EventArgs e)
     {
              foreach(Control c flowLayoutPanel1.Controls)
              {
                  if (c is Button)
                  {
                     Button newBtn = (Button)c;
                     int _val = Convert.ToInt32(newBtn.Text);
                     if(_val % 2 == 0)
                      newBtn.BackColor = Color.Green;
                    else
                     newBtn.BackColor=Color.Red;
                  }
              }
       }
