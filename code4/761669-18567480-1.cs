    foreach(Control c in this.Controls)
     {
          //Check if it's input control    
          if(c is TextBox)
          {
                 if (string.IsNullOrEmpty(c.Text))
                  {
                     MessageBox.Show("Value Required");
                   }
          }
      }
