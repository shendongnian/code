      foreach(Control ctrl in panel1.Controls)
      {
           if(ctrl is CheckBox)
           {
               CheckBox tempCheckBox = ctrl as CheckBox ; 
               if(tempCheckBox.Checked == true)
                   // do something.
           }
      }
