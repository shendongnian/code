        foreach (Control in MyForm.Controls)
        {
          if (Control is TextBox)
        {
          string input = null;
          TextBox myTextBox = Control as TextBox;
          
          if (String.IsNullOrEmpty(myTextBox.Text))
          {
            input = "0";
          }
          else
          {
            input = myTextBox.Text;
          }
    
         //Never worked with this, maybe you have to edit it for your behaviour.
         adp.InsertCommand.Parameters.Add("@taxDeduct", SqlDbType.VarChar).Value = input;
        }
        }
