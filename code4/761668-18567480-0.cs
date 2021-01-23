    foreach(Control c in this.Controls)
     {
          //Check if it's input control    
          if(c is TextBox)
          {
                 if (string.IsNullOrEmpty(c))
                  {
                     MessageBox.Show("Value Required");
                   }
          }
      }
