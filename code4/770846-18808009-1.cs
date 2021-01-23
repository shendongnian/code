    private void CheckCheckBoxes(string checkBoxName)
    {
       // this.Controls is a collection of all controls on the form (assuming this is run on the Form class)
       foreach(Control control in this.Controls)
       {
          if (control.Name == checkBoxName && control is CheckBox)
          {
             CheckBox checkBox = control as CheckBox;
             if (checkBox.Checked)
             {
                MessageBox.Show("Check box is checked");
             }
          }
       }
    }
